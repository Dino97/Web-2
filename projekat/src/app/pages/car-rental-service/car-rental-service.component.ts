import { Component, OnInit } from '@angular/core';
import { CarRentalService } from 'src/app/entities/cars/carRentalService/car-rental-service';
import { DataExchangeService } from 'src/app/services/data-exchange/data-exchange.service';
import { RentalAgencyService } from 'src/app/services/rentalAgency/rental-agency.service';
import { Company } from 'src/app/entities/company/company';

@Component({
  selector: 'app-car-rental-service',
  templateUrl: './car-rental-service.component.html',
  styleUrls: ['./car-rental-service.component.css']
})
export class CarRentalServiceComponent implements OnInit {
  message: CarRentalService
  company: Company;

  constructor(private data: DataExchangeService, private service: RentalAgencyService) { }

  ngOnInit(): void {
    this.data.currentMessage.subscribe(message => this.message = message);
    /*this.service.getAgency("Alamo").subscribe(
      res => {
        this.company = new Company(res["name"], res["description"], this.message.logo)
      },
      err => {
        console.log(err);
      }
    )*/
  }

}
