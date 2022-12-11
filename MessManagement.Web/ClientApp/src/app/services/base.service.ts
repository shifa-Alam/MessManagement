import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  params: {}
}
@Injectable({
  providedIn: 'root'
})
export class BaseService {

  baseUrl = "https://localhost:44458/";

  //prod
  // baseUrl = "http://localhost:5000/";



  constructor(private http: HttpClient) { }

  public deleteRequest(subUrl: string, id: number) {
    return this.http.delete<any>(this.baseUrl + subUrl + `?id=${id}`, {
      headers: {
        "Content-Type": "aplication/json"
      }
    });
  }
  public getRequest(subUrl: string, params?: any) {
    if (params) {
      httpOptions.params = params;
    }
    return this.http.get<any>(this.baseUrl + subUrl, httpOptions);
  }

  public postRequest(subUrl: string, body: any) {
    return this.http.post<any>(this.baseUrl + subUrl, JSON.stringify(body), httpOptions);
  }
}

