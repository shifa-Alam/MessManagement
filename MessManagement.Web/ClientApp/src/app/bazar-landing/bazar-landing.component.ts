import {  Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BazarAddComponent } from '../bazar-add/bazar-add.component';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { Bazar } from '../Models/bazar';
import { BazarFilter } from '../Models/filters/bazarFilter';
import { BazarService } from '../services/bazar.service';
import { DateUtil } from '../utils/DateUtil';

@Component({
  selector: 'app-bazar-landing',
  templateUrl: './bazar-landing.component.html',
  styleUrls: ['./bazar-landing.component.css']
})
export class BazarLandingComponent implements OnInit {
  dataSource!: MatTableDataSource<Bazar>;
  displayedColumns: string[] = [];

  isLoading: boolean = false;
  filter: BazarFilter = new BazarFilter();
  totalRecords: number = 0;

  constructor(private service: BazarService, public dialog: MatDialog) {
   
  }


  ngOnInit(): void {
    this.setColumn();
    this.initFilters();
    this.getBazars();
  }
  setColumn() {
    this.displayedColumns = ['id', 'bazarDate', 'memberName', 'amount', 'action'];
  }
  initFilters() {
    var date = new Date();
    var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
    var lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    this.filter.startDate = DateUtil.ConvertToActualDate(firstDay.toLocaleDateString());
    this.filter.endDate = DateUtil.ConvertToActualDate(lastDay.toLocaleDateString());
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
  onNameChange(event: any) {
    if (event)
      this.filter.memberName = event;
    this.getBazars();

  }
  onStartChange(event: any) {
    if (event.value)
      this.filter.startDate = DateUtil.ConvertToActualDate(event.value.toLocaleDateString());
    this.getBazars();
  }
  onEndChange(event: any) {
    if (event.value)
      this.filter.endDate = DateUtil.ConvertToActualDate(event.value.toLocaleDateString());
    this.getBazars();
  }
  pageChange(e: PageEvent) {
    this.filter.pageNumber = e.pageIndex + 1;
    this.filter.pageSize = e.pageSize;
    this.getBazars();

  }
  getBazars() {
    this.isLoading = true;
    this.service.getBazar(this.filter).subscribe(result => {
      this.totalRecords = result.totalItemCount;
      this.dataSource = new MatTableDataSource(result.subset);
      this.isLoading = false;
    },
      error => {
        this.dataSource = new MatTableDataSource();
        this.isLoading = false;
      }
    );
  }
}

