import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { Member } from '../Models/member';
import { MemberService } from '../services/member.service';

@Component({
  selector: 'app-member-landing',
  templateUrl: './member-landing.component.html',
  styleUrls: ['./member-landing.component.css']
})
export class MemberLandingComponent implements OnInit, AfterViewInit {
  dataSource!: MatTableDataSource<Member>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  members: Member[] = [];
  displayedColumns: string[] = [];
  color: string;

  constructor(private service: MemberService, public dialog: MatDialog) {
    this.color = "orange";
  }
  ngAfterViewInit(): void {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
    this.setColumn();
    this.getMembers();
  }
  setColumn() {
    this.displayedColumns = ['id', 'name', 'mobile', 'district', 'action'];
  }

  getMembers() {
    this.service.getMember().subscribe(result => {
      this.members = result;

      this.dataSource = new MatTableDataSource(this.members);
    },
      error => console.error(error));
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  add(){
    
  }
  edit(member: any) {
    if (member != null) {
      this.service.updateMember(member).subscribe(result => {
        console.log(result);
      },
        error => console.error(error));
    }
  }

  delete(id: number) {
    if (id) {
      const dialogRef = this.dialog.open(DeleteDialogComponent);

      dialogRef.afterClosed().subscribe(result => {
        console.log(`Dialog result: ${result}`);
        if (result) {
          this.service.deleteMember(id).subscribe(result => {
            console.log(result);
          },
            error => console.error(error));
        }
      });
    }
  }
}
