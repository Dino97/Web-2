import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { FlightService } from '../../services/flight/flight.service';
import { Flight } from '../../entities/flight/flight';

@Component({
  selector: 'app-flight-search',
  templateUrl: './flight-search.component.html',
  styleUrls: ['./flight-search.component.css']
})
export class FlightSearchComponent implements OnInit {
  flightForm: FormGroup;
  flightResults$: Observable<Flight[]>;

  constructor(private flights: FlightService) { }

  ngOnInit(): void {
    this.flightForm = new FormGroup({
      'from': new FormControl(null, Validators.required),
      'to': new FormControl(null, Validators.required),
      'departure': new FormControl(null),
      'landing': new FormControl(null),
      'tripType' : new FormControl(null),
      'passNum': new FormControl(1, Validators.required),
      'class' : new FormControl(null),
      'luggage' : new FormControl(0)
    })
  }

  search() {
    this.flights.searchFlights().toPromise().then((res: Flight[]) => console.log(res[0]));
  }
}
