import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReportComponent } from './report/report.component';
import { StudentCourseRegistrationComponent } from './student-course-registration/student-course-registration.component';
import { StudentRegistrationComponent } from './student-registration/student-registration.component';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { StudentComponent } from './student/student.component';
import { CourseComponent } from './course/course.component';
import { CourseDetailsComponent } from './course-details/course-details.component';
import { CourseRegistrationComponent } from './course-registration/course-registration.component';
import { FormsModule } from '@angular/forms';
import { StatusComponent } from './status/status.component';

@NgModule({
  declarations: [
    AppComponent,
    ReportComponent,
    StudentCourseRegistrationComponent,
    StudentRegistrationComponent,
    StudentDetailsComponent,
    StudentComponent,
    CourseComponent,
    CourseDetailsComponent,
    CourseRegistrationComponent,
    StatusComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
