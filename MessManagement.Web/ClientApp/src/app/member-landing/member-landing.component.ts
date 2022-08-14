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

  constructor(private service: MemberService) { }

  ngOnInit(): void {
    this.getMembers();

    //for (var i = 1; i < 10; i++) {
    //  let member: Member = new Member();
    //  member.id = i;
    //  member.firstName = "First Name" + i;
    //  member.lastName = "Last name" + i;
    //  member.mobileNo = "Mobile NO ..." + i;
    //  this.members.push(member);
    //}





  }


  getMembers() {
    this.service.getMember().subscribe(result => {
      this.members = result;
    },
      error => console.error(error));
  }
}
