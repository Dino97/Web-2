import { Injectable } from '@angular/core';
import { Airline } from 'src/app/entities/airline/airline';
import { CarRentalService } from 'src/app/entities/cars/carRentalService/car-rental-service';
import { CarRentalAgency } from 'src/app/entities/cars/carRentalAgency/car-rental-agency';
import { Location } from 'src/app/entities/location/location';
import { Car } from 'src/app/entities/cars/car/car';


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

  /*getRentalServices(){
    let sevices = new Array<CarRentalService>();

    let branchesEuropacar: CarRentalAgency[] = [ new CarRentalAgency(new Location("Serbia", "SRB", "Novi Sad", "Bulevar Jase Tomica 1", 0, 0))
                                                , new CarRentalAgency(new Location("Luxembourg", "LUX", "Luxembourg", "116 Route de Thionville", 0, 0))
                                                , new CarRentalAgency(new Location("Togo", "TGO", "Lome", "2295 Rue de L'Entente", 0, 0))
                                                , new CarRentalAgency(new Location("Turkey", "TUR", "Istanbul", "Istanbul Grand Airport", 0, 0))
                                                , new CarRentalAgency(new Location("Bosnia and Herzegovina", "BiH", "Tuzla", "ZAVNO BiH-a 13", 0, 0))
                                                , new CarRentalAgency(new Location("Norway", "NOR", "Gardermoen", "Oslo Airport Gardermoen", 0, 0))
                                                , new CarRentalAgency(new Location("Brasil", "BRA", "São Paulo", "Congonhas Airport", 0, 0))]

    let cars : Car[] = [ new Car("../../../assets/images/cars/yugo45.jpg", 1, 4, "Yugo 45", 3, branchesEuropacar[0], 40)
                        , new Car("../../../assets/images/cars/audia4.jpg", 0, 4, "Audi A4", 0, branchesEuropacar[3], 120)
                        , new Car("../../../assets/images/cars/bmw3.jpg", 0, 4, "BMW 3", 1, branchesEuropacar[6], 150)
                        , new Car("../../../assets/images/cars/vwgolf4.jpg", 1, 4, "Golf 4", 3, branchesEuropacar[4], 90)]

    const a1 = new CarRentalService("Alamo"
                                    , ""
                                    , "../../../assets/vectors/companies/car-rental-agencies/alamo.svg"
                                    , new Array<CarRentalAgency>()
                                    , new Array<Car>());
    const a2 = new CarRentalService("Hertz"
                                    , ""
                                    , "../../../assets/vectors/companies/car-rental-agencies/hertz.svg"
                                    , new Array<CarRentalAgency>()
                                    , new Array<Car>());
    const a3 = new CarRentalService("Europcar"
                                    , "The best offers for rent a car services, price stability, special offers designed to fit needs of our clients, the latest models of vehicles, large range of diesel and automatic vehicles, the youngest vehicles on the market, Europcar your reliable partner. You can rely on us. Weather you need daily rent in the country or abroad, temporary solution for couple of months or purchase on a longer period, Europcar is your reliable partner. With our fleet of over 50 groups and over 55 models of vehicle, from the smallest city vehicles and commercial vehicles, to business limos and 4x4 vehicles, Europcar is here to offer you best solution."
                                    , "../../../assets/vectors/companies/car-rental-agencies/europcar.svg"
                                    , branchesEuropacar
                                    , cars);

    sevices.push(a1);
    sevices.push(a2);
    sevices.push(a3);
  
    return sevices;
  }*/
}
