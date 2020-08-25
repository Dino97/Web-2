import { CarRentalAgency } from '../carRentalAgency/car-rental-agency';
import { Rating } from '../../rating/rating';

enum Manufacturer {
    AUDI, BMW, YUGO, VOLKSWAGEN
}

enum TransmissionType {
    AUTOMATIC, MANUAL
}

export class Car {
    image: string;
    transmission: TransmissionType;
    passengers: number;
    model: string;
    manufacturer: Manufacturer;
    availableIn: CarRentalAgency;
    pricePerDay: number;
    rating: Rating;

    constructor(image: string, transmission: TransmissionType, passengers: number,
         model: string, manufacturer: Manufacturer, availableIn: CarRentalAgency, ppd: number)
    {
        this.image = image;
        this.transmission = transmission;
        this.passengers = passengers;
        this.model = model;
        this.manufacturer = manufacturer;
        this.availableIn = availableIn;
        this.pricePerDay = ppd;
        this.rating = new Rating();
    }
}
