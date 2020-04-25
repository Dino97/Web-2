import { Car } from '../car/car';
import { CarRentalService } from '../carRentalService/car-rental-service';

export class CarRentalAgency {
    address: string;
    cars: Car[];
    ownedBy: CarRentalService;

    constructor(address: string, cars: Car[], owner: CarRentalService){
        this.address = address;
        this.cars = cars;
        this.ownedBy = owner;
    }
}
