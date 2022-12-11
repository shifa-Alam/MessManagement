import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Meal } from '../Models/meal';
import { BaseFilter } from '../Models/filters/baseFilter';
import { BaseService } from './base.service';
import { MealFilter } from '../Models/filters/mealFIlter';
import { HttpParams } from '@angular/common/http';

const subUrl = "Meal/";


@Injectable({
  providedIn: 'root'
})
export class MealService extends BaseService {
  deleteMeal(id: number): Observable<any> {
    return super.deleteRequest(subUrl + "DeleteMeal", id);
  }

  //constructor(http: HttpClient) {
  //  super(http)
  //}
  public getMeal(filter: MealFilter): Observable<any> {

    // return super.getRequest(subUrl +
    //   `GetMeals?pageNumber=${filter.pageNumber}&pageSize=${filter.pageSize}&startDate=${filter.startDate}&endDate=${filter.endDate}&memberName=${filter.memberName}`
    // );
    // let parameters = {"page":1,"per_page":1};
    
    return super.getRequest(subUrl +`GetMeals`,filter);
  }
  saveMeal(meal: Meal): Observable<any> {
    return super.postRequest(subUrl + "SaveMeal", meal);
  }
  saveMealRange(meals: Meal[]): Observable<any> {
    return super.postRequest(subUrl + "SaveMealRange", meals);
  }
  updateMeal(meal: Meal): Observable<any> {
    return super.postRequest(subUrl + "UpdateMeal", meal);
  }

  public getMembers(): Observable<any> {
    return super.getRequest(subUrl + "GetMembers");
  }
}
