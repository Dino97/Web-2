import { Airport } from '../airport/airport';
import { Time } from '@angular/common';

export class Flight {
    from: Airport;
    to: Airport;
    departure: Date;
    arrival: Date;
    price: number;
    duration: number;

    constructor(from, to, departure, arrival, price){
        this.from = from;
        this.to = to;
        this.departure = departure;
        this.arrival = arrival;
        this.price = price;

        if(this.departure.getDate() === this.arrival.getDate()){
            this.duration = this.arrival.getTime() - this.departure.getTime();
        } else {
            this.duration = 24 * (this.arrival.getDate() - this.departure.getDate()) + (this.arrival.getTime() - this.departure.getTime());
        }
    }
}
