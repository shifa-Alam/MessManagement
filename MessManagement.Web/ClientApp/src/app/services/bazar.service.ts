import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bazar } from '../Models/bazar';
import { BazarFilter } from '../Models/filters/bazarFilter';
import { BaseService } from './base.service';

const subUrl = "Bazar/";


@Injectable({
  providedIn: 'root'
})
export class BazarService extends BaseService {
  deleteBazar(id: number): Observable<any> {
    return super.deleteRequest(subUrl + "DeleteBazar", id);
  }

  public getBazar(filter: BazarFilter): Observable<any> {
    return super.getRequest(subUrl + "GetBazars", filter);
  }
  saveBazar(entity: Bazar): Observable<any> {
    return super.postRequest(subUrl + "SaveBazar", entity);
  }
  updateBazar(entity: Bazar): Observable<any> {
    return super.postRequest(subUrl + "UpdateBazar", entity);
  }

  public getMembers(): Observable<any> {
    return super.getRequest(subUrl + "GetMembers");
  }
}
