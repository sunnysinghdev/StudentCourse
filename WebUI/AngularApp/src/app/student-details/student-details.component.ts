import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AppCommonService } from '../app-common.service';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.scss']
})
export class StudentDetailsComponent implements OnInit {

  dataItem: any = [];

  constructor(private http: HttpClient, private service: AppCommonService) { }

  ngOnInit(): void {
    this.http.get(environment.apiEndpoint + "Student").subscribe((res:any)=>{
      res.forEach((element: any) => {
        try{
        element.dob = element.dob.split("T")[0];
        }catch{}
      });
      this.dataItem = res;
    });
    this.service.statusChange.subscribe((data:any)=>{
      this.ngOnInit();
    })
  }
  edit(data: any){
    this.service.onEditStudent.emit(data);
  }
  deleteStudent(id: Number){
    this.http.delete(environment.apiEndpoint+"Student/"+id).subscribe((res:any)=>{
      this.service.statusChange.emit(res);
    },(err:any)=>{
      this.service.statusChange.emit(err);
    });
  }
}
