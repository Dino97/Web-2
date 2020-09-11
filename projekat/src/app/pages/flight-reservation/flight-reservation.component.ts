import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { FriendService } from 'src/app/services/friend/friend.service';
import { FlightService } from 'src/app/services/flight/flight.service';
import { ReservationService } from 'src/app/services/reservation/reservation.service';

@Component({
  selector: 'app-flight-reservation',
  templateUrl: './flight-reservation.component.html',
  styleUrls: ['./flight-reservation.component.css']
})
export class FlightReservationComponent implements OnInit {

  step: number;
  seats: number[];
  friends: Object[];
  reservedSeats: number[];
  flight: any;
  
  passengers = [];
  passports = [];

  numberOfSeats = 0;
  selfSelected: boolean;

  

  constructor(private route: ActivatedRoute,
              private flightService: FlightService, 
              private reservationService: ReservationService, 
              private friendService: FriendService) {
    this.step = 0;
    this.seats = [];
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      let flightId = +params['id'];

      this.flightService.getFlight(flightId).subscribe(flight => { 
        this.flight = flight;
        this.reservedSeats = [];
        
        for (let index = 0; index < this.flight.seats.length; index++) {
          const element = this.flight.seats[index];

          if (element != '0')
            this.reservedSeats.push(index);
        }
      });
    });
    this.friendService.getFriends().subscribe(friends => this.friends = friends);
  }

  selectSeats(seats: number[]) {
    this.numberOfSeats = 0;

    // Count selected seats.
    for (let index = 0; index < seats.length; index++) {
      const element = seats[index];

      if (element == 1) {
        this.numberOfSeats++;
        this.seats.push(index + 1);
      }
    }

    if (this.numberOfSeats > 0)
    {
      // if only one seat is selected, do not offer friends as option.
      if (this.numberOfSeats == 1)
        this.friends = [];
      
      this.step = 1;
    }
  }

  createReservation() {
    this.reservationService.createReservation({
      flightId: this.flight.id,
      passengers: this.passengers,
      seats: this.seats,
      passports: this.passports
    });
  }
}
