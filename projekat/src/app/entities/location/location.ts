export class Location {
    country: string;
    countryShort: string
    city: string;
    address: string;
    lat: number;
    lon: number;

    constructor(country: string, countryShort: string, city: string, address: string, lat: number, lon: number){
        this.country = country;
        this.countryShort = countryShort;
        this.city =  city;
        this.address = address;
        this.lat = lat;
        this.lon = lon;
    }
}
