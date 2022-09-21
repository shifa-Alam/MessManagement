import { Component, OnInit } from '@angular/core';
import { Report } from '../Models/report';
import { MemberService } from '../services/member.service';

@Component({
  selector: 'app-report-landing',
  templateUrl: './report-landing.component.html',
  styleUrls: ['./report-landing.component.css']
})
export class ReportLandingComponent implements OnInit {
  isLoading: boolean = false;
  report: Report = new Report();
  constructor(private service: MemberService) { }

  ngOnInit(): void {
    this.getReport();
  }

  getReport() {
    this.isLoading = true;
    this.service.getReport().subscribe(result => {
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
