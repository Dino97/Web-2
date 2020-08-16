import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-hero-comp',
  templateUrl: './hero-comp.component.html',
  styleUrls: ['./hero-comp.component.css']
})
export class HeroCompComponent implements OnInit {
  //@Input() travelType:string;
  flightForm: FormGroup;
  carForm: FormGroup;
  image: string;

  constructor() { }

  ngOnInit(): void {
    this.image = "../../../assets/images/" + location.pathname.split('/')[1] + "Hero.jpg"

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
