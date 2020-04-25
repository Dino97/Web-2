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
}
