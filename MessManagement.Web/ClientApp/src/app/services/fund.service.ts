import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Fund } from '../Models/fund';
import { BaseService } from './base.service';
import { FundFilter } from '../Models/filters/fundFilter';



const subUrl = "Fund/";


@Injectable({
  providedIn: 'root'
})
export class FundService extends BaseService {
  deleteFund(id: number): Observable<any> {
    return super.deleteRequest(subUrl + "DeleteFund", id);
  }

  //constructor(http: HttpClient) {
  //  super(http)
  //}
  public getFund(filter: FundFilter): Observable<any> {
    return super.getRequest(subUrl +"GetFunds",filter);
  }
  saveFund(fund: Fund): Observable<any> {
    return super.postRequest(subUrl + "SaveFund", fund);
  }
  saveFundRange(funds: Fund[]): Observable<any> {
    return super.postRequest(subUrl + "SaveFundRange", funds);
  }
  updateFund(fund: Fund): Observable<any> {
    return super.postRequest(subUrl + "UpdateFund", fund);
  }

  public getMembers(): Observable<any> {
    return super.getRequest(subUrl + "GetMembers");
  }
}
