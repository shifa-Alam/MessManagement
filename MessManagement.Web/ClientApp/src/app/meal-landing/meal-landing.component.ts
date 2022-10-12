import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { MealAddRangeComponent } from '../meal-add-range/meal-add-range.component';
import { MealAddComponent } from '../meal-add/meal-add.component';
import { Meal } from '../Models/meal';
import { MealService } from '../services/meal.service';

@Component({
  selector: 'app-meal-landing',
  templateUrl: './meal-landing.component.html',
  styleUrls: ['./meal-landing.component.css']
})
export class MealLandingComponent implements OnInit, AfterViewInit {
  dataSource!: MatTableDataSource<Meal>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  meals: Meal[] = [];
  displayedColumns: string[] = [];
  color: string;
  isLoading: boolean = false;

  constructor(private service: MealService, public dialog: MatDialog) {
    this.color = "orange";
  }
  ngAfterViewInit(): void {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
    this.setColumn();
    this.getMeals();
  }
  setColumn() {
    this.displayedColumns = ['id', 'mealDate', 'memberName', 'quantity', 'action'];
  }

  getMeals() {
    this.isLoading = true;
    this.service.getMeal().subscribe(result => {
      this.meals = result;
      this.dataSource = new MatTableDataSource(this.meals);
      this.isLoading = false;
    },
      error => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
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
}

