import { Component, OnInit } from '@angular/core';
import { Member } from '../Models/member';
import { MemberService } from '../services/member.service';

@Component({
  selector: 'app-member-landing',
  templateUrl: './member-landing.component.html',
  styleUrls: ['./member-landing.component.css']
})
export class MemberLandingComponent implements OnInit {

  members: Member[] = [];
  displayedColumns: string[] = [];
  color: string;
  constructor(private service: MemberService) {
    this.color = "orange";
  }

  ngOnInit(): void {
    this.setColumn();
    this.getMembers();
  }
  setColumn() {
    this.displayedColumns = ['id', 'name', 'mobile', 'district'];
  }


  getMembers() {
    this.service.getMember().subscribe(result => {
      this.members = result;
    },
      error => console.error(error));
  }

  clickedRows = new Set<Member>();
}
