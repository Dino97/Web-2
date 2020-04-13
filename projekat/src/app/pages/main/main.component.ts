import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/entities/city/city';
import { CityService } from 'src/app/services/city/city.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  cities: City[];
  flightForm: FormGroup;

  constructor(private cityService: CityService) { }

  ngOnInit(): void {
    this.cities = this.cityService.mockedCities();
    this.initForm();
  }

  initForm(){
    this.flightForm = new FormGroup({
      'origin': new FormControl(null, Validators.required),
      'destination': new FormControl(null, Validators.required),
      'from': new FormControl(null),
      'to': new FormControl(null),
      'passNum': new FormControl(1, Validators.required)
    })
  }

  onSubmit(){}
}
