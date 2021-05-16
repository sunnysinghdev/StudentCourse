import { Component, Input, OnInit } from '@angular/core';
import { AppCommonService } from '../app-common.service';

@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.scss']
})
export class StatusComponent implements OnInit {
  message: string;
  color = "black";
  constructor(private service: AppCommonService) {
    this.message = "";
  }

  ngOnInit(): void {
    this.service.statusChange.subscribe((data: any) => {
      console.log(data);
      this.message = JSON.stringify(data);
      // if (data) {
      //   if (data.message) {
      //     this.color = "green";
      //     this.message = data.message;
      //   } else {
      //     this.color = "red";
      //     this.message = data.title;
      //   }
      //   //this.message = JSON.stringify(data);
      // }
      // else {
      //   this.message = "";
      //   this.color = "black";
      // }
    });
  }


}
