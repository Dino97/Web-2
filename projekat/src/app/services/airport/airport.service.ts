import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class AirportService {

  readonly baseUri: string = "http://localhost:52482/api/";

  constructor(private http: HttpClient) { }

  getAirports() {
    return this.http.get(this.baseUri + "Flight/GetAirports");
  }
}
