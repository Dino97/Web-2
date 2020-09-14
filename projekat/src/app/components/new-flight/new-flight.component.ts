import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AirportService } from 'src/app/services/airport/airport.service';
import { FlightService } from 'src/app/services/flight/flight.service';
import { ToastrService } from 'ngx-toastr';

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

  errorMsg = "";
  today: Date;



  constructor(private airportService: AirportService, private flightService: FlightService, private toastr: ToastrService) {
    this.airports = [];
  }

  ngOnInit(): void {
    this.today = new Date();
    this.airportService.getAirports().subscribe(res => this.airports = res);
  }

  createFlight(departure, landing, departureTime, landingTime, distance, price) {
    if (this.validate() == false)
      return;

    this.flightService.newFlight({ 
      departure,
      landing,
      departureTime,
      landingTime,
      flightDistance: +distance,
      ticketPrice: +price,
      destinations: [
        this.location1,
        this.location2,
        this.location3,
        this.location4,
        this.location5
      ]
    }).subscribe(_ => {
      departure = landing = null;
      departureTime = landingTime = undefined;
      distance = price = "";
      this.location1 = this.location2 = this.location3 = this.location4 = this.location5 = "";
      this.toastr.success("New flight successfully created.", "Flight created")
    });
  }

  validate(): boolean {
    let result: boolean = true;
    this.errorMsg = "";

    if (this.location1 == undefined || this.location2 == undefined)
    {
      this.errorMsg += "Location 1 & 2 must be selected.\n"
      result = false;
    }

    if ((this.location1 == this.location2 && this.location1 != undefined) || 
        (this.location2 == this.location3 && this.location2 != undefined) || 
        (this.location3 == this.location4 && this.location3 != undefined) || 
        (this.location4 == this.location5 && this.location4 != undefined)) {
      this.errorMsg += "Two consecutive locations cannot have same destination.\n";
      result = false;
    }

    return result;
  }
}
