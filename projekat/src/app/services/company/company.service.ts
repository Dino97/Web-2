import { Injectable } from '@angular/core';
import { Company } from 'src/app/entities/company/company';
import { Airline } from 'src/app/entities/airline/airline';
import { CarRentalService } from 'src/app/entities/cars/carRentalService/car-rental-service';


@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor() { }

  getAirlines(){
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

  getRentalServices(){
    let sevices = new Array<CarRentalService>();

    const a1 = new CarRentalService("Alamo"
                                    , ""
                                    , "../../../assets/vectors/companies/car-rental-agencies/alamo.svg");
    const a2 = new CarRentalService("Hertz"
                                    , ""
                                    , "../../../assets/vectors/companies/car-rental-agencies/hertz.svg");
    const a3 = new CarRentalService("Europacar"
                                    , "The best offers for rent a car services, price stability, special offers designed to fit needs of our clients, the latest models of vehicles, large range of diesel and automatic vehicles, the youngest vehicles on the market, Europcar your reliable partner. You can rely on us. Weather you need daily rent in the country or abroad, temporary solution for couple of months or purchase on a longer period, Europcar is your reliable partner. With our fleet of over 50 groups and over 55 models of vehicle, from the smallest city vehicles and commercial vehicles, to business limos and 4x4 vehicles, Europcar is here to offer you best solution."
                                    , "../../../assets/vectors/companies/car-rental-agencies/europcar.svg");

    sevices.push(a1);
    sevices.push(a2);
    sevices.push(a3);
  
    return sevices;
  }
}
