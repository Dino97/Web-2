import { Injectable } from '@angular/core';
import { Company } from 'src/app/entities/company/company';
import { Airline } from 'src/app/entities/airline/airline';
import { CarRental } from 'src/app/entities/carRental/car-rental';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor() { }

  mockedAirlines(){
    let airlines = new Array<Airline>();

    const a1 = new Airline("Air Serbia", "Hvala Arapima", "../../../assets/vectors/companies/airlines/airserbia.svg");
    const a3 = new Airline("Etihad Airways", "", "../../../assets/vectors/companies/airlines/etihad.svg");
    const a4 = new Airline("Lufthansa", "", "../../../assets/vectors/companies/airlines/lufthansa.svg");
    //const a5 = new Airline("Ryanair", "", "../../../assets/vectors/companies/airlines/ryanair.svg");
    const a7 = new Airline("Wizz Air", "", "../../../assets/vectors/companies/airlines/wizz.svg");

    airlines.push(a1);
    airlines.push(a3);
    airlines.push(a4);
    //airlines.push(a5);
    airlines.push(a7);

    return airlines;
  }

  mockedRentalAgencies(){
    let agencies = new Array<CarRental>();

    const a1 = new CarRental("Alamo", "", "../../../assets/vectors/companies/car-rental-agencies/alamo.svg");
    const a2 = new CarRental("Hertz", "", "../../../assets/vectors/companies/car-rental-agencies/hertz.svg");
    const a3 = new CarRental("Europacar", "", "../../../assets/vectors/companies/car-rental-agencies/europcar.svg");

    agencies.push(a1);
    agencies.push(a2);
    agencies.push(a3);
  
    return agencies;
  }
}
