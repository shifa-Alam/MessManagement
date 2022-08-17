import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../Models/member';
import { BaseService } from './base.service';

const subUrl = "Member/";


@Injectable({
  providedIn: 'root'
})
export class MemberService extends BaseService {
  deleteMember(id: number):Observable<any> {
    return super.deleteRequest(subUrl+"DeleteMember",id);
  }

  //constructor(http: HttpClient) {
  //  super(http)
  //}
  public getMember(): Observable<any> {
    return super.getRequest(subUrl+"GetMembers");
  }

  updateMember(member: Member):Observable<any> {
    return super.postRequest(subUrl+"UpdateMember",member);
  }
}
