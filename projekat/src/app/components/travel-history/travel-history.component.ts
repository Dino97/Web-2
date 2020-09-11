import { Component, OnInit } from '@angular/core';
import { ReservationService } from 'src/app/services/reservation/reservation.service';

@Component({
  selector: 'app-travel-history',
  templateUrl: './travel-history.component.html',
  styleUrls: ['./travel-history.component.css']
})
export class TravelHistoryComponent implements OnInit {

  reservations;

  cancelTime = 3;



  constructor(private reservationService: ReservationService) { }

  ngOnInit(): void {
    this.loadReservations();
  }

  cancelReservation(reservation) {
    if (!this.canCancel(reservation))
      return;

    this.reservationService.cancelReservation(reservation);
  }

  canCancel(reservation): boolean {
    let t1 = new Date().getTime();
    let t2 = new Date(reservation.flight.departure).getTime();

    return (t2 - t1) / (1000 * 60 * 60) > this.cancelTime;
  }

  loadReservations() {
    this.reservationService.getUserReservations().subscribe(res => this.reservations = res);
  }
}
