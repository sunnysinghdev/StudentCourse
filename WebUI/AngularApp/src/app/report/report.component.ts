import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AppCommonService } from '../app-common.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss']
})
export class ReportComponent implements OnInit {
  dataItem: any= [
    {
      studentName: "Sunny",
      courseName:"Course"
    }
  ]
  constructor(private httpClient: HttpClient, private service:AppCommonService) { }

  ngOnInit(): void {
    this.httpClient.get( environment.apiEndpoint + "Student/Course").subscribe((res: any)=>{
      this.dataItem = res;
    });
    this.service.statusChange.subscribe((data:any)=>{
      this.ngOnInit();
    })
  }

}
