import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AppCommonService } from '../app-common.service';

@Component({
  selector: 'app-student-course-registration',
  templateUrl: './student-course-registration.component.html',
  styleUrls: ['./student-course-registration.component.scss']
})
export class StudentCourseRegistrationComponent implements OnInit {

  courseId = 0;
  studentId = 0;
  courses: any = [];
  students: any = [];
  selectedCourseIndex = 0;
  selectedStudentIndex = 0;
  constructor(private http: HttpClient, private service: AppCommonService) { }

  ngOnInit(): void {
    this.http.get(environment.apiEndpoint + "Course").subscribe((data: any) => {
      this.courses = data;
    });
    this.http.get(environment.apiEndpoint + "Student").subscribe((data: any) => {
      this.students = data;
    });
  }
  selectCourse($event: any) {
    console.log($event.target.options.sele);
    this.selectedCourseIndex = $event.target.options.selectedIndex;
  }
  selectStudent($event: any) {
    console.log($event.target.options.sele);
    this.selectedStudentIndex = $event.target.options.selectedIndex;
  }
  addCourse() {
    //if (this.selectedCourseIndex > 0 && this.selectedStudentIndex > 0) {
      let req: any = {};
      req.studentId = this.students[this.selectedStudentIndex].id;
      req.courseId = this.courses[this.selectedCourseIndex].id;
      console.log(req);
      this.http.post(environment.apiEndpoint + "Student/Course", req).subscribe((res: any) => {
        this.service.statusChange.emit(res);
      }, (err: any) => {
        this.service.statusChange.emit(err);
      });
    //}
  }

}
