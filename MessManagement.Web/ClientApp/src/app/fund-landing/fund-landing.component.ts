import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Fund } from '../Models/fund';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { FundAddComponent } from '../fund-add/fund-add.component';
import { DateUtil } from '../utils/DateUtil';

import { FundService } from '../services/fund.service';
import { FundFilter } from '../Models/filters/fundFilter';


export class FundReport {
  totalEarning: number = 0;
  totalDeduction: number = 0;
  summary: number = 0;
};
@Component({
  selector: 'app-fund-landing',
  templateUrl: './fund-landing.component.html',
  styleUrls: ['./fund-landing.component.css']
})

export class FundLandingComponent implements OnInit {

  dataSource!: MatTableDataSource<Fund>;

  isLoading: boolean = false;

  displayedColumns: string[] = [];

  filter: FundFilter = new FundFilter();
  totalRecords: number = 0;
  fundReport: FundReport = new FundReport();



  constructor(private service: FundService, public dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.setColumn();
    this.initFilters();
    this.getFunds();
  }

  setColumn() {
    this.displayedColumns = ['id', 'fundDate', 'memberName', 'amount', 'action'];
  }
  initFilters() {
    var date = new Date();
    var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
    var lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    this.filter.startDate = DateUtil.ConvertToActualDate(firstDay.toLocaleDateString());
    this.filter.endDate = DateUtil.ConvertToActualDate(lastDay.toLocaleDateString());
  }
  add() {
    const dialogRef = this.dialog.open(FundAddComponent, {
      position: { top: '10px' },
      data: {
        Fund: new Fund()
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getFunds();
    });
  }
  edit(fund: any) {
    console.log(fund);
    const dialogRef = this.dialog.open(FundAddComponent, {
      position: { top: '10px' },
      data: {
        fund: fund
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getFunds();
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
          this.service.deleteFund(id).subscribe(result => {
            this.getFunds();
          },
            error => console.error(error));
        }
      });
    }
  }
  onNameChange(event: any) {
    if (event)
      this.filter.memberName = event;
    this.getFunds();

  }
  onStartChange(event: any) {
    if (event.value)
      this.filter.startDate = DateUtil.ConvertToActualDate(event.value.toLocaleDateString());
    this.getFunds();
  }
  onEndChange(event: any) {
    if (event.value)
      this.filter.endDate = DateUtil.ConvertToActualDate(event.value.toLocaleDateString());
    this.getFunds();
  }
  pageChange(e: PageEvent) {
    this.filter.pageNumber = e.pageIndex + 1;
    this.filter.pageSize = e.pageSize;
    this.getFunds();

  }
  getFunds() {
    this.isLoading = true;
    this.service.getFund(this.filter).subscribe(result => {
      this.totalRecords = result.totalItemCount;
      console.log(result.subset);
      this.fundReport = new FundReport();
      result.subset.forEach((item: Fund) => {
        if (item.isDeduction) {
          this.fundReport.totalDeduction += item.amount;
        } else if (!item.isDeduction) {
          this.fundReport.totalEarning += item.amount;
        }
      });
      this.fundReport.summary = this.fundReport.totalEarning - this.fundReport.totalDeduction;

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

