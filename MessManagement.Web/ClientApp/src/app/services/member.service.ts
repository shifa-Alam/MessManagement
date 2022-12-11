import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MemberFilter } from '../Models/filters/memberFilter';
import { Member } from '../Models/member';
import { BaseService } from './base.service';

const subUrl = "Member/";


@Injectable({
  providedIn: 'root'
})
export class MemberService extends BaseService {

  deleteMember(id: number): Observable<any> {
    return super.deleteRequest(subUrl + "DeleteMember", id);
  }

 
  // public getMember(): Observable<any> {
  //   return super.getRequest(subUrl + "GetMembers");
  // }
  public getMember(filter: MemberFilter): Observable<any> {
    return super.getRequest(subUrl + "GetMembers", filter);
  }
  saveMember(member: Member): Observable<any> {
    return super.postRequest(subUrl + "SaveMember", member);
  }
  updateMember(member: Member): Observable<any> {
    return super.postRequest(subUrl + "UpdateMember", member);
  }
  public getReport(startDate:string,endDate:string): Observable<any> {
    return super.getRequest(subUrl + "GetReport"+`?startDate=${startDate}&endDate=${endDate}`);
  }
}
