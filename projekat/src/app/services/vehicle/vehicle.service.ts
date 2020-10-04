import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, Output, EventEmitter } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  branchId: number;
  @Output() carUpdateEmitter: EventEmitter<any> = new EventEmitter<any>();

  readonly BaseURI: string = "http://localhost:52482/api/Car/"

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  formModel = this.fb.group({
    'brand': ['', [Validators.required]],
    'model': ['', [Validators.required]],
    'pricePerDay': ['', [Validators.required, Validators.min(0)]],
    'image': ['', [Validators.required]],
    'drive': [''],
    'numberOfPassengers': ['', [Validators.required, Validators.min(2), Validators.max(9)]],
    'automatic': [''],
    'airconditioner': ['']
  })

  addCar(image){
    let body = {
      'BranchId': this.branchId,
      'Brand': this.formModel.value.brand,
      'Model': this.formModel.value.model,
      'PricePerDay': this.formModel.value.pricePerDay,
      'Image': image,
      'Drive': this.formModel.value.drive,
      'NumberOfPassengers': this.formModel.value.numberOfPassengers,
      'Automatic': this.formModel.value.automatic ? "true" : "false",
      'Airconditioner': this.formModel.value.airconditioner ? "true" : "false"
    }

    return this.http.post(this.BaseURI + "AddCar/", body);
  }

  getCars(branchId: number){
    let params = new HttpParams().set('stringId', branchId.toString())
    return this.http.get(this.BaseURI + "GetCars/", {params})
  }

  getCarUpdateEmitter(){
    return this.carUpdateEmitter;
  }
}
