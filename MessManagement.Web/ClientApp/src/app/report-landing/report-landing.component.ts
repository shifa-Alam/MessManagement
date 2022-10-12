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
  startDate: Date = new Date();
  endDate: Date = new Date();

  constructor(private service: MemberService) { }

  ngOnInit(): void {
    
  }
  submit() {
    
    this.getReport(this.startDate.toDateString(), this.endDate.toDateString());
  }

  getReport(startDate: string, endDate: string) {
    this.isLoading = true;
   
    this.service.getReport(DateUtil.ConvertToActualDate(startDate),DateUtil.ConvertToActualDate(endDate)).subscribe(result => {
      this.report = result;
      console.log(result);
      this.isLoading = false;
    },
      error => {
        console.error(error);
        this.isLoading = false;
      }
    );
  }

}
