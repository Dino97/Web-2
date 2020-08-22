import { Car } from '../car/car';
import { CarRentalService } from '../carRentalService/car-rental-service';
import { Location } from '../../location/location';

export class CarRentalAgency {
    location: Location;
    cars: Car[];

    constructor(location: Location, cars: Car[]){
        this.location = location;
        this.cars = cars;
    }
}
