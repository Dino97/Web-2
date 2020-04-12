import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/entities/city/city';
import { CityService } from 'src/app/services/city/city.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  cities: City[];

  constructor(private cityService: CityService) { }

  ngOnInit(): void {
    this.cities = this.cityService.mockedCities();
  }

}
