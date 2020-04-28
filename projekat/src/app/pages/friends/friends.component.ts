import { Component, OnInit } from '@angular/core';
import { Flight } from "../../entities/flight/flight"
import { Airport } from 'src/app/entities/airport/airport';

class FlightInvitation
{
  fromUser: string;
  flight: Flight;

  constructor(fromUser: string, flight: Flight) {
    this.fromUser = fromUser;
    this.flight = flight;
  }
}

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  getFlightInvitations(): FlightInvitation[] {
    let a1 = new Airport("", "", "Cairo", "Egypt");
    let f1 = new Flight(a1, a1, new Date(), new Date(), undefined);

    return [ new FlightInvitation("Petrov", f1), new FlightInvitation("Petrov", f1) ];
  }

  getFriendRequests(): string[] {
    return [ "Petrov", "Djole" ];
  }
}