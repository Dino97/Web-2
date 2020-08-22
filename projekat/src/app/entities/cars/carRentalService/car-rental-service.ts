import { Company } from '../../company/company';
import { CarRentalAgency } from '../carRentalAgency/car-rental-agency';

export class CarRentalService extends Company {
    branches : Array<CarRentalAgency>;

    constructor(name: string, description: string, logo: string, branches: Array<CarRentalAgency>){
        super(name, description, logo);

        this.branches = branches;
    }
}