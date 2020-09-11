import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  readonly baseUri: string = "http://localhost:52482/api/";



  constructor(private http: HttpClient) { }

  getUserReservations() {
    return this.http.get(this.baseUri + "Reservation/GetUserReservations");
  }

  getFlightInvitations() {
    return this.http.get(this.baseUri + "Reservation/GetFlightInvitations");
  }

  createReservation(data) {
    this.http.post(this.baseUri + "Reservation/CreateReservation", data).subscribe();
  }

  cancelReservation(reservation) {
    let options = {
      params: new HttpParams().set("id", reservation.id)
    }

    this.http.post(this.baseUri + "Reservation/CancelReservation", null, options).subscribe();
  }

  acceptInvitation(invitation) {
    let options = {
      params: new HttpParams().set("id", invitation.id)
    }

    return this.http.post(this.baseUri + "Reservation/AcceptFlightInvite", null, options);
  }

  declineInvitation(invitation) {
    let options = {
      params: new HttpParams().set("id", invitation.id)
    }

    return this.http.post(this.baseUri + "Reservation/DeclineFlightInvite", null, options);
  }
}
