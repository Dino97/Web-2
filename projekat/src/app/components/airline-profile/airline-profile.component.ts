import { Component, OnInit } from '@angular/core';
import { Airline } from 'src/app/entities/airline/airline';

@Component({
  selector: 'app-airline-profile',
  templateUrl: './airline-profile.component.html',
  styleUrls: ['./airline-profile.component.css']
})
export class AirlineProfileComponent implements OnInit {

  profile: Airline;

  constructor() { 
    this.profile = new Airline("Air Serbia", "Promo description", "");
  }

  ngOnInit(): void {}
}