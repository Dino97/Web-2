class Location {
    address: string;
}

export class Airline {
    name: string;
    location: Location;
    description: string;
    //destinations:
    //flights:
    //discountedTickets:
    //configuration?
    //pricelist

    constructor(name: string, description: string) {
        this.name = name;
        this.description = description;
    }
}
