import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppCommonService {

  statusChange = new EventEmitter<any>();
  onEditStudent = new EventEmitter<any>();
  onEditCourse = new EventEmitter<any>();
  constructor() { }
}
