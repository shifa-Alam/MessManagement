import { Component, OnInit } from '@angular/core';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Meal } from '../Models/meal';
import { Member } from '../Models/member';
import { MealService } from '../services/meal.service';
import { DateUtil } from '../utils/DateUtil';

@Component({
  selector: 'app-meal-add-range',
  templateUrl: './meal-add-range.component.html',
  styleUrls: ['./meal-add-range.component.css']
})
export class MealAddRangeComponent implements OnInit {

  meals: Meal[] = [];
  isLoading: boolean = false;
  members: Member[] = [];

  displayedColumns = ['member', 'quantity', 'date'];
  dataSource = new MatTableDataSource();
  mealDate: any;

  constructor(public service: MealService,
    public dialogRef: MatDialogRef<MealAddRangeComponent>) { }

  ngOnInit(): void {
    this.dialogRef.updateSize('75%');
    this.getMembers();

  }
  createMeal() {
    this.members.forEach(m => {
      let meal: Meal = new Meal();
      meal.memberFirstName = m.firstName;
      meal.memberLastName = m.lastName;
      meal.memberId = m.id;
      meal.quantity = 0;
      meal.mealDate = new Date();
      this.meals.push(meal);
    });
    this.dataSource.data = this.meals;
  }
  getMembers() {
    this.isLoading = true;
    this.service.getMembers().subscribe(result => {
      this.members = result;
      this.createMeal();
      this.isLoading = false;
    },
      error => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }

  cancel() {
    this.dialogRef.close();
  }
  changeMealDate(date: MatDatepickerInputEvent<any>) {
    console.log(date);
    let convertedDate = DateUtil.ConvertToActualDate(date.value);
    console.log(convertedDate);

    this.meals.forEach(e => {
      e.mealDate = DateUtil.ConvertToActualDate(date.value);

    });
  }
  submit() {
    
    this.service.saveMealRange(this.meals).subscribe(result => {
      this.dialogRef.close();
    },
      error => console.error(error));


  }
}
