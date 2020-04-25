import { Company } from '../../company/company';

export class CarRentalService extends Company {
    review: number;

    constructor(name: string, description: string, logo: string){
        super(name, description, logo)

        this.review = 0;
    }
}