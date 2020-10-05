import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';


@Injectable({
  providedIn: 'root'
})
export class CarReservationService {
  @Output() SearchClickEmitter: EventEmitter<any> = new EventEmitter<any>();

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  formModel = this.fb.group({
    'pickupLocation': ['', [Validators.required]],
    'fromDate': ['', [Validators.required]],
    'fromTime': [''],
    'toDate': ['', [Validators.required]],
    'toTime': [''],
    'sameDrop': [''],
  })

  search(){
    let params = {
      'PickupLocation': this.formModel.value.pickupLocation,
      'FromDate': this.formModel.value.fromDate,
      'FromTime': this.formModel.value.fromTime,
      'ToDate': this.formModel.value.toDate,
      'ToTime': this.formModel.value.toTime,
      'SameDrop': this.formModel.value.sameDrop ? "true" : "false"
    }

    return this.http.get("http://localhost:52482/api/Car/SearchResults", { params })
  }

  getSearchClickEmitter(){
    return this.SearchClickEmitter;
  }
}
