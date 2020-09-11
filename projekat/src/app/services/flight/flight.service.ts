import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Flight } from '../../entities/flight/flight'

@Injectable({
  providedIn: 'root'
})
export class FlightService {

  readonly baseUri: string = "http://localhost:52482/api/";

  constructor(private http: HttpClient) { }

  getFlight(id) {
    let options = {
      params: new HttpParams().set("id", id)
    }

    return this.http.get(this.baseUri + "Flight/GetFlight", options);
  }

  newFlight(flightData) {
    console.log(flightData)
    this.http.post(this.baseUri + "Flight/NewFlight", flightData).subscribe();
  }

  searchFlights(from, to, departure, landing, passengers) {
    let tripType = 1;
    let luggage = 10;
    
    return this.http.post(this.baseUri + "Flight/Search", { from, to, departure, landing, tripType, passengers, luggage });
  }
}
