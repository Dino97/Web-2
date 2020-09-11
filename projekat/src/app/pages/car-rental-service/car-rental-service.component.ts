import { Component, OnInit } from '@angular/core';
import { RentalAgencyService } from 'src/app/services/rentalAgency/rental-agency.service';
import { Company } from 'src/app/entities/company/company';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-car-rental-service',
  templateUrl: './car-rental-service.component.html',
  styleUrls: ['./car-rental-service.component.css']
})
export class CarRentalServiceComponent implements OnInit {
  //message: CarRentalService
  company: Company;

  constructor(/*private data: DataExchangeService,*/ private service: RentalAgencyService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    //this.data.currentMessage.subscribe(message => this.message = message);
    let companyName;
    this.route.params.subscribe(params => companyName = params["name"]);

    this.service.getAgency(companyName).subscribe(
      res => {
        this.company = new Company(res["name"], res["description"], res["logo"]);
      },
      err => {
        console.log(err);
      }
    )
  }

}
