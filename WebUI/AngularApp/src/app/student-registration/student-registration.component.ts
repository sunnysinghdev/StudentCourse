import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AppCommonService } from '../app-common.service';

@Component({
  selector: 'app-student-registration',
  templateUrl: './student-registration.component.html',
  styleUrls: ['./student-registration.component.scss']
})
export class StudentRegistrationComponent implements OnInit {
  student: any = {
    id: 0,
    firstName: "abc",
    lastName: "singh",
    dob: "2021-05-16T03:08:38.488Z",
    contactNumber: "989877776677"
  }
  constructor(private http:HttpClient, private service:AppCommonService) { }

  ngOnInit(): void {
    this.clear();
    this.service.onEditStudent.subscribe((data:any)=>{
      this.student = data;
    });
  }
  submit() {
    if (this.student.id != 0) {
      this.http.put(environment.apiEndpoint + "Student/" + this.student.id, this.student).subscribe((res: any) => {
        this.clear();        
        console.log(res);
        this.service.statusChange.emit(res);

      });
    } else {
      
      this.http.post(environment.apiEndpoint + "Student", this.student).subscribe((res: any) => {
        console.log(res);
        this.clear();
        this.service.statusChange.emit(res);

      },(error: any)=>{
        console.log(error);
        this.service.statusChange.emit(error);
      });
    }
  }
  clear(){
    this.student.id = 0;
    this.student.firstName = null;
    this.student.lastName = null;
    this.student.dob = null;
    this.student.contactNumber = null;
  }
}
