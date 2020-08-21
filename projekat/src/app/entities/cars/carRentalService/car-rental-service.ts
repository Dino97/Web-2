import { Company } from '../../company/company';

export class CarRentalService extends Company {
    
    constructor(name: string, description: string, logo: string){
        super(name, description, logo);
    }
}