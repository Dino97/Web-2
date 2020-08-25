import { Car } from '../car/car';
import { CarRentalService } from '../carRentalService/car-rental-service';
import { Location } from '../../location/location';

export class CarRentalAgency {
    location: Location;

    constructor(location: Location){
        this.location = location;
    }
}
