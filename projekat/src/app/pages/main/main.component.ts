import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  //cities: City[];
  flightForm: FormGroup;
  carForm: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.initFlightForm();
    this.initCarForm();
  }

  initFlightForm(){
    this.flightForm = new FormGroup({
      'origin': new FormControl(null, Validators.required),
      'destination': new FormControl(null, Validators.required),
      'from': new FormControl(null),
      'to': new FormControl(null),
      'passNum': new FormControl(1, Validators.required)
    })
  }

  initCarForm(){
    this.carForm = new FormGroup({
      'pickup': new FormControl(null, Validators.required),
      'fromDate': new FormControl(null),
      'fromTime': new FormControl(null),
      'toDate': new FormControl(null),
      'toTime': new FormControl(null)
    })
  }

  onSubmitFlight(){}

  onSubmitRent(){}

  pathIsFlights(){
    if(location.pathname.includes("/flights")){
      return true;
    } else {
      return false;
    }
  }

  pathIsCars(){
    if(location.pathname.includes("/cars")){
      return true;
    } else {
      return false;
    }
  }
}
