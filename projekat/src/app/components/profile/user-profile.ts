export class UserProfile {
    username: string;
    firstName: string;
    lastName: string;
    address: string;


    constructor(username: string, firstName: string, lastName: string, address: string) {
        this.username = username;
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
    }

    fullname(): string {
        return this.firstName + " " + this.lastName;
    }
}