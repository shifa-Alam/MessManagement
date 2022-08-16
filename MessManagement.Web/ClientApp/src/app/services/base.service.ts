import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseService {

  baseUrl = "https://localhost:44458/";


  constructor(private http: HttpClient) { }

  public getRequest(subUrl: string) {
    return this.http.get<any>(this.baseUrl + subUrl, {
      headers: {
        "Content-Type": "aplication/json"
      }
    });
  }

  public postRequest(subUrl: string, body: any) {
    return this.http.post<any>(this.baseUrl + subUrl, body, {
      headers: {
        "Content-Type": "aplication/json"
      }
    });
  }
}

