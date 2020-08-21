export class Rating {
    numOfVotes : number;
    rating : number;

    constructor(){
        this.numOfVotes = 0;
        this.rating = 0;
    }

    rate(rating: number): void{
        let newRating : number = (this.rating * this.numOfVotes) + rating;
        newRating /= (++this.numOfVotes);
        
        this.rating = newRating;
    }
}
