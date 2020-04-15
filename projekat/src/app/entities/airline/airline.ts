class Location {
    address: string;
}

import { Company } from '../company/company';

export class Airline extends Company{
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
