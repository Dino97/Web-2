import { Injectable } from '@angular/core';
import { City } from 'src/app/entities/city/city';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor() { }

  mockedCities(){
    let cities = new Array<City>();

    const c1 = new City("New York", "../../../assets/images/cities/new-york.jpg");
    const c2 = new City("Belgrade", "../../../assets/images/cities/new-york.jpg");
    const c3 = new City("Amsterdam", "../../../assets/images/cities/new-york.jpg");
    const c4 = new City("Paris", "../../../assets/images/cities/new-york.jpg");
    const c5 = new City("Berlin", "../../../assets/images/cities/new-york.jpg");
    const c6 = new City("Tokyo", "../../../assets/images/cities/new-york.jpg");
    const c7 = new City("Moscow", "../../../assets/images/cities/new-york.jpg");
    const c8 = new City("Sydney", "../../../assets/images/cities/new-york.jpg");
    const c9 = new City("London", "../../../assets/images/cities/new-york.jpg");
    const c10 = new City("Cairo", "../../../assets/images/cities/new-york.jpg");

    cities.push(c1);
    cities.push(c2);
    cities.push(c3);
    cities.push(c4);
    cities.push(c5);
    cities.push(c6);
    cities.push(c7);
    cities.push(c8);
    cities.push(c9);
    cities.push(c10);

    return cities;
  }
}

