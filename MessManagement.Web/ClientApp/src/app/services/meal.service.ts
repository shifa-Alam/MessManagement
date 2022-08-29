import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meal } from '../Models/meal';
import { BaseService } from './base.service';

const subUrl = "Meal/";


@Injectable({
  providedIn: 'root'
})
export class MealService extends BaseService {
  deleteMeal(id: number):Observable<any> {
    return super.deleteRequest(subUrl+"DeleteMeal",id);
  }

  //constructor(http: HttpClient) {
  //  super(http)
  //}
  public getMeal(): Observable<any> {
    return super.getRequest(subUrl+"GetMeals");
  }
  saveMeal(meal: Meal):Observable<any> {
    return super.postRequest(subUrl+"SaveMeal",meal);
  }
  updateMeal(meal: Meal):Observable<any> {
    return super.postRequest(subUrl+"UpdateMeal",meal);
  }

  public getMembers(): Observable<any> {
    return super.getRequest(subUrl+"GetMembers");
  }
}
