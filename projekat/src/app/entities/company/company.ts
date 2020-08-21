import { Rating } from '../rating/rating';

export class Company {
    name: string;
    description: string;
    logo: string;
    rating: Rating;

    constructor(name: string, description: string, logo: string){
        this.description = description;
        this.name = name;
        this.logo = logo;
        this.rating = new Rating();
    }
}
