import { Component, OnInit } from '@angular/core';
import { ReservationService } from 'src/app/services/reservation/reservation.service';

@Component({
  selector: 'app-travel-history',
  templateUrl: './travel-history.component.html',
  styleUrls: ['./travel-history.component.css']
})
export class TravelHistoryComponent implements OnInit {

  reservations;



  constructor(private reservationService: ReservationService) { }

  ngOnInit(): void {
    this.reservationService.getUserReservations().subscribe(res => { this.reservations = res; console.log(res) });
  }

  cancelReservation() {
    
  }
}
