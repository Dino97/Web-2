import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { FlightService } from '../../services/flight/flight.service';
import { Flight } from '../../entities/flight/flight';
import { AirportService } from 'src/app/services/airport/airport.service';
import { CompanyService } from 'src/app/services/company/company.service';

@Component({
  selector: 'app-flight-search',
  templateUrl: './flight-search.component.html',
  styleUrls: ['./flight-search.component.css']
})
export class FlightSearchComponent implements OnInit {
  flightForm: FormGroup;
  searchResults: any[];
  filteredSearchResults: any[];

  airports;
  airlines;
  today: Date;

  // Filtering
  airlineFilter = "";
  flightDurationFilter = "";
  maxPriceFilter = "";



  constructor(private flightService: FlightService, 
              private airportService: AirportService,
              private companyService: CompanyService) { }

  ngOnInit(): void {
    this.today = new Date();

    this.flightForm = new FormGroup({
      'from': new FormControl(null, Validators.required),
      'to': new FormControl(null, Validators.required),
      'departure': new FormControl(null, Validators.required),
      'landing': new FormControl(null, Validators.required),
      'tripType' : new FormControl(null),
      'passNum': new FormControl(1),
      'class' : new FormControl(null),
      'luggage' : new FormControl(0)
    })

    this.airportService.getAirports().subscribe(res => this.airports = res);
    this.companyService.getAirlines().subscribe(res => this.airlines = res);
  }

  search() {
    this.flightService.searchFlights( this.flightForm.controls['from'].value, 
                                      this.flightForm.controls['to'].value, 
                                      this.flightForm.controls['departure'].value, 
                                      this.flightForm.controls['landing'].value,
                                      this.flightForm.controls['passNum'].value
                                    ).subscribe((res: any[]) => { this.searchResults = res; this.filterResults(); })
  }

  filterResults() {
    this.filteredSearchResults = this.searchResults;

    console.log(this.airlineFilter);
    if (this.airlineFilter != "") {
      this.filteredSearchResults = this.filteredSearchResults.filter(f => f.airline.name === this.airlineFilter);
    }

    if (this.flightDurationFilter.trim() != "") {
      this.filteredSearchResults = this.filteredSearchResults.filter(f => f.flightDuration >= +this.flightDurationFilter);
    }

    if (this.maxPriceFilter.trim() != "") {
      this.filteredSearchResults = this.filteredSearchResults.filter(f => f.ticketPrice >= +this.maxPriceFilter);
    }
  }
}
