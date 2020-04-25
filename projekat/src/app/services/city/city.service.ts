import { Injectable } from '@angular/core';
import { City } from 'src/app/entities/city/city';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor() { }

  getCities(){
    //let cities = new Array<City>();
    let id = 0;

    const c1 = new City("New York", "../../../assets/images/cities/new-york.jpg", id++);
    const c2 = new City("Belgrade", "../../../assets/images/cities/new-york.jpg", id++);
    const c3 = new City("Amsterdam", "../../../assets/images/cities/new-york.jpg", id++);
    const c4 = new City("Paris", "../../../assets/images/cities/new-york.jpg", id++);
    const c5 = new City("Berlin", "../../../assets/images/cities/new-york.jpg", id++);
    const c6 = new City("Tokyo", "../../../assets/images/cities/new-york.jpg", id++);
    const c7 = new City("Moscow", "../../../assets/images/cities/new-york.jpg", id++);
    const c8 = new City("Sydney", "../../../assets/images/cities/new-york-flipped.jpg", id++);
    const c9 = new City("London", "../../../assets/images/cities/new-york.jpg", id++);
    const c10 = new City("Cairo", "../../../assets/images/cities/new-york.jpg", id++);

    const destinations = [
      {continent: "Europe", cities: [c2, c3, c4, c5, c7, c9]},
      {continent: "Nort America", cities: [c1]},
      {continent: "Australia", cities: [c8]},
      {continent: "Asia", cities: [c6]},
      {continent: "Africa", cities: [c10]}
    ];

    return destinations;
  }
}

