import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { MealAddRangeComponent } from '../meal-add-range/meal-add-range.component';
import { MealAddComponent } from '../meal-add/meal-add.component';
import { MealFilter } from '../Models/filters/mealFilter';
import { Meal } from '../Models/meal';
import { MealService } from '../services/meal.service';
import { DateUtil } from '../utils/DateUtil';

@Component({
  selector: 'app-meal-landing',
  templateUrl: './meal-landing.component.html',
  styleUrls: ['./meal-landing.component.css']
})
export class MealLandingComponent implements OnInit {
  dataSource!: MatTableDataSource<Meal>;

  isLoading: boolean = false;

  displayedColumns: string[] = [];

  filter: MealFilter = new MealFilter();
  totalRecords: number = 0;

  constructor(private service: MealService, public dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.setColumn();
    this.initFilters();
    this.getMeals();
  }

  setColumn() {
    this.displayedColumns = ['id', 'mealDate', 'memberName', 'quantity', 'action'];
  }
  initFilters() {
    var date = new Date();
    var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
    var lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    this.filter.startDate = DateUtil.ConvertToActualDate(firstDay.toLocaleDateString());
    this.filter.endDate = DateUtil.ConvertToActualDate(lastDay.toLocaleDateString());
  }
  add() {
    const dialogRef = this.dialog.open(MealAddRangeComponent, {
      position: { top: '10px' },
      // data: {
      //   meal: new Meal()
      // }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getMeals();
    });
  }
  edit(meal: any) {
    const dialogRef = this.dialog.open(MealAddComponent, {
      position: { top: '10px' },
      data: {
        meal: meal
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getMeals();
    });

  }
  delete(id: number) {
    if (id) {
      const dialogRef = this.dialog.open(DeleteDialogComponent, {
        position: { top: '10px' },
        // width:'20%'
      });

      dialogRef.afterClosed().subscribe(result => {

        if (result) {
          this.service.deleteMeal(id).subscribe(result => {
            this.getMeals();
          },
            error => console.error(error));
        }
      });
    }
  }
  onNameChange(event: any) {
    if (event)
      this.filter.memberName = event;
    this.getMeals();

  }
  onStartChange(event: any) {
    if (event.value)
      this.filter.startDate = DateUtil.ConvertToActualDate(event.value.toLocaleDateString());
    this.getMeals();
  }
  onEndChange(event: any) {
    if (event.value)
      this.filter.endDate = DateUtil.ConvertToActualDate(event.value.toLocaleDateString());
    this.getMeals();
  }
  pageChange(e: PageEvent) {
    this.filter.pageNumber = e.pageIndex + 1;
    this.filter.pageSize = e.pageSize;
    this.getMeals();

  }
  getMeals() {
    this.isLoading = true;
    this.service.getMeal(this.filter).subscribe(result => {
      this.totalRecords = result.totalItemCount;
      this.dataSource = new MatTableDataSource(result.subset);

      this.isLoading = false;
    },
      error => {
        this.dataSource = new MatTableDataSource();
        this.isLoading = false;
      }
    );

  }
}

