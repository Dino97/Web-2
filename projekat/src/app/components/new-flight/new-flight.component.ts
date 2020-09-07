import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AirportService } from 'src/app/services/airport/airport.service';

@Component({
  selector: 'app-new-flight',
  templateUrl: './new-flight.component.html',
  styleUrls: ['./new-flight.component.css']
})
export class NewFlightComponent implements OnInit {

  airports;
  unusedAirports;

  location1;
  location2;
  location3;
  location4;
  location5;

  constructor(private airportService: AirportService) {
    this.airports = [];
  }

  ngOnInit(): void {
    this.airportService.getAirports().subscribe(res => { this.airports = res; console.log(res) });
  }

  createFlight() {

  }
}
