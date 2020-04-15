import { Injectable } from '@angular/core';
import { Company } from 'src/app/entities/company/company';
import { Airline } from 'src/app/entities/airline/airline';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor() { }

  mockedCompanies(){
    let companies = new Array<Company>();

    const a1 = new Airline("Air Serbia", "Hvala Arapima", "../../../assets/vectors/companies/airlines/airserbia.svg");
    const a3 = new Airline("Etihad Airways", "", "../../../assets/vectors/companies/airlines/etihad.svg");
    const a4 = new Airline("Lufthansa", "", "../../../assets/vectors/companies/airlines/lufthansa.svg");
    const a5 = new Airline("Ryanair", "", "../../../assets/vectors/companies/airlines/ryanair.svg");
    const a7 = new Airline("Wizz Air", "", "../../../assets/vectors/companies/airlines/wizz.svg");

    companies.push(a1);
    companies.push(a3);
    companies.push(a4);
    companies.push(a5);
    companies.push(a7);

    return companies;
  }
}
