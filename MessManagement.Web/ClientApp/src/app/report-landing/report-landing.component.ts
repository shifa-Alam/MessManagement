import { Component, OnInit } from '@angular/core';
import { Report } from '../Models/report';
import { MemberService } from '../services/member.service';
import { DateUtil } from '../utils/DateUtil';

@Component({
  selector: 'app-report-landing',
  templateUrl: './report-landing.component.html',
  styleUrls: ['./report-landing.component.css']
})
export class ReportLandingComponent implements OnInit {
  isLoading: boolean = false;
  report: Report = new Report();
  startDate: any;
  endDate: any;
  // startDate: Date = new Date();
  // endDate: Date = new Date();

  constructor(private service: MemberService) { }

  ngOnInit(): void {
    var date = new Date();
    var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
    var lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    this.startDate = DateUtil.ConvertToActualDate(firstDay.toLocaleDateString());
    this.endDate = DateUtil.ConvertToActualDate(lastDay.toLocaleDateString());

    this.getReport(this.startDate, this.endDate);
  }
  submit() {

    // this.getReport(this.startDate.toDateString(), this.endDate.toDateString());
    this.getReport(this.startDate, this.endDate);
  }

  getReport(startDate: string, endDate: string) {
    this.isLoading = true;

    this.service.getReport(DateUtil.ConvertToActualDate(startDate), DateUtil.ConvertToActualDate(endDate)).subscribe(result => {
      this.report = result;
      console.log(result);
      this.isLoading = false;
    },
      error => {
        console.error(error);
        this.isLoading = false;
        this.report = new Report();
      }
    );
  }

}
