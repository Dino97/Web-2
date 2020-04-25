import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/entities/city/city';
import { CityService } from 'src/app/services/city/city.service';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {
  destinations: {continent: string, cities: City[]}[];

  constructor(private cityService: CityService) { }

  ngOnInit(): void {
    this.destinations = this.cityService.getCities();
  }

}
