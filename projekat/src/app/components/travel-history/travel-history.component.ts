import { Component, OnInit } from '@angular/core';
import { ReservationService } from 'src/app/services/reservation/reservation.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-travel-history',
  templateUrl: './travel-history.component.html',
  styleUrls: ['./travel-history.component.css']
})
export class TravelHistoryComponent implements OnInit {

  reservations;

  cancelTime = 3;



  constructor(private reservationService: ReservationService,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadReservations();
  }

  cancelReservation(reservation) {
    if (!this.canCancel(reservation))
      return;

    this.reservationService.cancelReservation(reservation).subscribe(_ => {
      this.toastr.success("", "Reservation cancelled");
      this.loadReservations();
    });
  }

  canCancel(reservation): boolean {
    let t1 = new Date().getTime();
    let t2 = new Date(reservation.flight.departure).getTime();

    return (t2 - t1) / (1000 * 60 * 60) > this.cancelTime;
  }

  flightFinished(reservation): boolean {
    let t1 = new Date().getTime();
    let t2 = new Date(reservation.flight.landing).getTime();
    
    return (t2 - t1) / (1000 * 60 * 60) < 0;
  }

  loadReservations() {
    this.reservationService.getUserReservations().subscribe(res => this.reservations = res);
  }
}
