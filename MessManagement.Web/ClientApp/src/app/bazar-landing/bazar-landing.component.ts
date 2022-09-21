import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { BazarAddComponent } from '../bazar-add/bazar-add.component';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { Bazar } from '../Models/bazar';
import { BazarService } from '../services/bazar.service';

@Component({
  selector: 'app-bazar-landing',
  templateUrl: './bazar-landing.component.html',
  styleUrls: ['./bazar-landing.component.css']
})
export class BazarLandingComponent implements OnInit, AfterViewInit {
  dataSource!: MatTableDataSource<Bazar>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  bazars: Bazar[] = [];
  displayedColumns: string[] = [];
  color: string;
  isLoading: boolean = false;

  constructor(private service: BazarService, public dialog: MatDialog) {
    this.color = "orange";
  }
  ngAfterViewInit(): void {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
    this.setColumn();
    this.getBazars();
  }
  setColumn() {
    this.displayedColumns = ['id', 'bazarDate', 'image', 'memberName', 'amount', 'action'];
  }

  getBazars() {
    this.isLoading = true;
    this.service.getBazar().subscribe(result => {
      this.bazars = result;
      this.dataSource = new MatTableDataSource(this.bazars);
      this.isLoading = false;
    },
      error => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  add() {
    const dialogRef = this.dialog.open(BazarAddComponent, {
      position: { top: '10px' },
      data: {
        bazar: new Bazar()
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getBazars();
    });
  }
  edit(bazar: any) {
    const dialogRef = this.dialog.open(BazarAddComponent, {
      position: { top: '10px' },
      data: {
        bazar: bazar
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getBazars();
    });

  }

  delete(id: number) {
    if (id) {
      const dialogRef = this.dialog.open(DeleteDialogComponent, {
        position: { top: '10px' },
        // width:'20%'
      });

      dialogRef.afterClosed().subscribe(result => {

        if (result) {
          this.service.deleteBazar(id).subscribe(result => {
            this.getBazars();
          },
            error => console.error(error));
        }
      });
    }
  }
}

