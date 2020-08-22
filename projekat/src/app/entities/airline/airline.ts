import { Company } from '../company/company';
import { Location } from '../location/location';

export class Airline extends Company {
    location: Location;
    //destinations:
    //flights:
    //discountedTickets:
    //configuration?
    //pricelist

    constructor(name: string, description: string, logo: string) {
        super(name, description, logo);
    }
}
