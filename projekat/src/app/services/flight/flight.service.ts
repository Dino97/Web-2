import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Flight } from '../../entities/flight/flight'

@Injectable({
  providedIn: 'root'
})
export class FlightService {

  private flightsUrl = 'api/flight';

  constructor(private http: HttpClient) { }

  searchFlights(): Observable<Flight[]> {
    return this.http.get<Flight[]>(this.flightsUrl);
  }
}
