import { Company } from '../../company/company';
import { CarRentalAgency } from '../carRentalAgency/car-rental-agency';
import { Car } from '../car/car';

export class CarRentalService extends Company {
    branches;

    /*constructor(name: string, description: string, logo: string, branches: Array<CarRentalAgency>, cars: Array<Car>){
        super(name, description, logo);

        this.branches = branches;
        this.cars = cars;
    }*/
    constructor(name: string, description: string, logo: string) { 
        super(name, description, logo);
    }
}