import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'AngularApp2';

  constructor(private http: HttpClient) {
    this.http.get("http://localhost:56639/Course").subscribe((res: any) => {
      console.log(res);
    });
}
}
