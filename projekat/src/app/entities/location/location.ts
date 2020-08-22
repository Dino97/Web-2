export class Location {
    country: string;
    city: string;
    zipCode: number;
    adress: string;
    lat: number;
    lon: number;

    constructor(country: string, city: string, zipCode: number, adress: string, lat: number, lon: number){
        this.country = country;
        this.city =  city;
        this. zipCode = zipCode;
        this.adress = adress;
        this.lat = lat;
        this.lon = lon;
    }
}
