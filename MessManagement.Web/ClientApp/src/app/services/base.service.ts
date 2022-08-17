import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

const  httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
}
@Injectable({
  providedIn: 'root'
})
export class BaseService {

  baseUrl = "https://localhost:44458/";


  constructor(private http: HttpClient) { }

  public deleteRequest(subUrl: string,id:number) {
    return this.http.delete<any>(this.baseUrl + subUrl+`?id=${id}`, {
      headers: {
        "Content-Type": "aplication/json"
      }
    });
  }
  public getRequest(subUrl: string) {
    return this.http.get<any>(this.baseUrl + subUrl, httpOptions);
  }

  public postRequest(subUrl: string, body: any) {
    return this.http.post<any>(this.baseUrl + subUrl, JSON.stringify(body), httpOptions);
  }
}

