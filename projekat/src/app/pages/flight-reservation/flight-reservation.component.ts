import { Component, OnInit } from '@angular/core';
import { FriendService } from 'src/app/services/friend/friend.service';
import { FlightService } from 'src/app/services/flight/flight.service';

@Component({
  selector: 'app-flight-reservation',
  templateUrl: './flight-reservation.component.html',
  styleUrls: ['./flight-reservation.component.css']
})
export class FlightReservationComponent implements OnInit {

  step: number;
  seats: number[];
  friends: Object[];
  seatOccupant = [];
  reservedSeats: number[];

  numberOfSeats = 0;
  selfSelected: boolean;


  constructor(private flightService: FlightService, private friendService: FriendService) {
    this.step = 0;
    this.seats = [];
    this.reservedSeats = [5, 3];
  }

  ngOnInit(): void {
    this.flightService.getFlight(2).subscribe(flight => console.log(flight));
    this.friendService.getFriends().subscribe(friends => this.friends = friends);
  }

  selectSeats(seats: number[]) {
    this.numberOfSeats = 0;

    for (let index = 0; index < seats.length; index++) {
      const element = seats[index];

      if (element == 1) {
        this.numberOfSeats++;
        this.seats.push(index + 1);
      }
    }

    /*if (this.numberOfSeats > 1)
      this.step = 1;
    else
      this.step = 2;*/

      this.step = 1;

      // if only one seat is selected, do not offer friends as option
      if (this.numberOfSeats == 1)
        this.friends = [];
  }

  back() {
    if (this.step == 2) {
      if (this.numberOfSeats > 1) {
        this.step = 1;
      }
      else {
        this.step = 0;
      }

      return;
    }

    this.step--;
  }
}
