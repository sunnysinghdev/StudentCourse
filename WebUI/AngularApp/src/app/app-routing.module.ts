import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseComponent } from './course/course.component';
import { ReportComponent } from './report/report.component';
import { StudentCourseRegistrationComponent } from './student-course-registration/student-course-registration.component';
import { StudentComponent } from './student/student.component';

const routes: Routes = [
  {
    path: "",
    component: ReportComponent

  },
  {
    path: "report",
    component: ReportComponent

  }
  , {
    path: "student",
    component: StudentComponent

  },
  {
    path: "course",
    component: CourseComponent

  },
  {
    path: "student/course",
    component: StudentCourseRegistrationComponent

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
