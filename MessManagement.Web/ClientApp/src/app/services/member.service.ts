import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';

const subUrl = "Member/";


@Injectable({
  providedIn: 'root'
})
export class MemberService extends BaseService {

  //constructor(http: HttpClient) {
  //  super(http)
  //}
  public getMember(): Observable<any> {
    return super.getRequest(subUrl+"GetMembers");
  }
}
