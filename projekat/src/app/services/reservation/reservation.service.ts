import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  readonly baseUri: string = "http://localhost:52482/api/";



  constructor(private http: HttpClient) { }

  getUserReservations() {
    return this.http.get(this.baseUri + "Reservation/GetUserReservations");
  }

  createReservation(data) {
    this.http.post(this.baseUri + "Reservation/CreateReservation", data).subscribe();
  }
}
