import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class RentalAgencyService {
  readonly BaseURI: string = "http://localhost:52482/api/RentalAgency/"

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  formModel = this.fb.group({
    'Country': ['', [Validators.required]],
    'City': ['', [Validators.required]],
    'Address': [''],
    'WorksFrom': ['', [Validators.required]],
    'WorksTo': ['', [Validators.required]],
    'ContactNumber': [''],
    'NearAirport': ['']
  })

  getAgency(companyName){
    let params = new HttpParams().set('companyName', companyName)
    return this.http.get(this.BaseURI + "LoadAgency/", { params });
  }

  getAgencies(){
    return this.http.get(this.BaseURI + "LoadAgencies/");
  }

  getBranches(){
    return this.http.get(this.BaseURI + "LoadBranches/");
  }

  postBranch(){
    var body = {
      Country: this.formModel.value.Country,
      City: this.formModel.value.City,
      Address: this.formModel.value.Address,
      WorksFrom: this.formModel.value.WorksFrom,
      WorksTo: this.formModel.value.WorksTo,
      ContactNumber: this.formModel.value.ContactNumber,
      NearAirport: this.formModel.value.NearAirport
    }

    return this.http.post(this.BaseURI + "AddBranch/", body);
  }
}
