import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { MemberAddComponent } from '../member-add/member-add.component';
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
    this.displayedColumns = ['id','image', 'name', 'mobile', 'district', 'action'];
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
  add() {
    const dialogRef = this.dialog.open(MemberAddComponent, {
      position: { top: '10px' },
      data: {
        member: new Member()
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getMembers();
    });
  }
  edit(member: any) {
    const dialogRef = this.dialog.open(MemberAddComponent, {
      position: { top: '10px' },
      data: {
        member: member
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getMembers();
    });

  }

  delete(id: number) {
    if (id) {
      const dialogRef = this.dialog.open(DeleteDialogComponent,{
        position: { top: '10px' },
        // width:'20%'
      });

      dialogRef.afterClosed().subscribe(result => {
       
        if (result) {
          this.service.deleteMember(id).subscribe(result => {
            this.getMembers();
          },
            error => console.error(error));
        }
      });
    }
  }
}
