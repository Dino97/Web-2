import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RentalAgencyService {
  readonly BaseURI: string = "http://localhost:52482/api/RentalAgency/"

  constructor(private http: HttpClient) { }

  getAgency(companyName){
    let params = new HttpParams().set('companyName', companyName)
    return this.http.get(this.BaseURI + "LoadAgency/", { params });
  }

  getAgencies(){
    return this.http.get(this.BaseURI + "LoadAgencies/");
  }
}
