import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Meal } from '../Models/meal';
import { Member } from '../Models/member';
import { MealService } from '../services/meal.service';

export interface mealFormGroup {
  memberId: FormControl<number>;
  quantity: FormControl<number>;
  mealDate: FormControl<any>;
}
@Component({
  selector: 'app-meal-add',
  templateUrl: './meal-add.component.html',
  styleUrls: ['./meal-add.component.css']
})
export class MealAddComponent implements OnInit {

  meal: Meal = new Meal();
  mealForm!: FormGroup<mealFormGroup>;
  isLoading: boolean = false;
  members: Member[] = [];
  selectedMemberId: number = 0;
  constructor(
    public service: MealService,
    public fb: FormBuilder,
    public dialogRef: MatDialogRef<MealAddComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      meal: Meal
    }
  ) {
    Object.assign(this.meal, data.meal);
  }
  ngOnInit(): void {
    this.getMembers();

    this.dialogRef.updateSize('75%')
    this.createMealForm();
    this.setValue();

  }
  getMembers() {
    this.isLoading = true;
    this.service.getMembers().subscribe(result => {
      this.members = result;
      this.isLoading = false;
    },
      error => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }
  createMealForm() {
    this.mealForm = new FormGroup<mealFormGroup>({
      memberId: new FormControl<number>(0,{ nonNullable: true, validators: [Validators.required] }),
      quantity: new FormControl<number>(0, { nonNullable: true, validators: [Validators.required] }),
      mealDate: new FormControl<Date>(new Date(), { nonNullable: true, validators: [Validators.required] })
    });
  }

  setValue() {
    if (this.meal) {
      this.mealForm.patchValue({
        memberId: this.meal.memberId,
        quantity: this.meal.quantity,
        mealDate: this.meal.mealDate

      })
    }
  }
  convert(str:string) {
    var date = new Date(str),
      mnth = ("0" + (date.getMonth() + 1)).slice(-2),
      day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join("-");
  }

  cancel() {
    this.dialogRef.close();
  }
  submit() {
    console.log(this.mealForm);

    this.meal.memberId = this.mealForm.value.memberId as number;
    this.meal.quantity = this.mealForm.value.quantity as number;
    this.meal.mealDate = this.mealForm.value.mealDate as Date;
    this.meal.mealDate = this.convert(this.mealForm.value.mealDate);
    console.log(this.meal);

    if (this.meal.id) {
      this.service.updateMeal(this.meal).subscribe(result => {
        this.dialogRef.close();
      },
        error => console.error(error));

    } else {

      this.service.saveMeal(this.meal).subscribe(result => {
        this.dialogRef.close();
      },
        error => console.error(error));


    }





  }
}
