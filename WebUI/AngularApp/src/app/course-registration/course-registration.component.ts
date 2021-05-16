import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AppCommonService } from '../app-common.service';

@Component({
  selector: 'app-course-registration',
  templateUrl: './course-registration.component.html',
  styleUrls: ['./course-registration.component.scss']
})
export class CourseRegistrationComponent implements OnInit {
  course: any = {
    id: 0,
    name: "C#",
    description: "Premium Course",

  }
  constructor(private http: HttpClient, private service: AppCommonService) { }

  ngOnInit(): void {
    //this.clear();
    this.service.onEditCourse.subscribe((data: any) => {
      this.course = data;
    });
  }
  clear() {
    this.course.id = 0;
    this.course.name = null;
    this.course.description = null;

  }
  submit() {
    if (this.course.id != 0) {
      this.http.put(environment.apiEndpoint + "Course/" + this.course.id, this.course).subscribe((res: any) => {
        console.log(res);
        this.clear();
        this.service.statusChange.emit(res);
      }, (err: any) => {
        this.service.statusChange.emit(err);

      });
    } else {

      this.http.post(environment.apiEndpoint + "Course", this.course).subscribe((res: any) => {
        this.clear();
        console.log(res);
        this.service.statusChange.emit(res);
      
      }, (err: any) => {
        this.service.statusChange.emit(err);

      });
    }
  }

}
