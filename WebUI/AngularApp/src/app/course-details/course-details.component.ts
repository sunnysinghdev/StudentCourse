import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AppCommonService } from '../app-common.service';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.scss']
})
export class CourseDetailsComponent implements OnInit {
  dataItem: any=[];

  constructor(private http: HttpClient, private service: AppCommonService) { }

  ngOnInit(): void {
    this.http.get(environment.apiEndpoint + "Course").subscribe((res: any) => {
      this.dataItem = res;
    });
    this.service.statusChange.subscribe((data:any)=>{
      this.ngOnInit();
    })
  }

  edit(data: any) {
    this.service.onEditCourse.emit(data);
  }
  deleteCourse(id: Number) {
    this.http.delete(environment.apiEndpoint + "Course/" + id).subscribe((res: any) => {
      this.service.statusChange.emit(res);
    }, (err: any) => {
      this.service.statusChange.emit(err);
    });
  }

}
