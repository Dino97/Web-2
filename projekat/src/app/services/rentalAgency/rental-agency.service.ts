import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RentalAgencyService {
  readonly BaseURI: string = "http://localhost:52482/api/"

  constructor(private http: HttpClient) { }

  getAgency(companyName){
    return this.http.get(this.BaseURI + "RentalAgency/LoadAgency", companyName);
  }
}
