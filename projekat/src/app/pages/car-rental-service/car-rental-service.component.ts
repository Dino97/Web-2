import { Component, OnInit } from '@angular/core';
import { RentalAgencyService } from 'src/app/services/rentalAgency/rental-agency.service';
import { Company } from 'src/app/entities/company/company';
import { ActivatedRoute, Router } from '@angular/router';
import { CarRentalService } from 'src/app/entities/cars/carRentalService/car-rental-service';
import { DataExchangeService } from 'src/app/services/data-exchange/data-exchange.service';

@Component({
  selector: 'app-car-rental-service',
  templateUrl: './car-rental-service.component.html',
  styleUrls: ['./car-rental-service.component.css']
})
export class CarRentalServiceComponent implements OnInit {
  //message: CarRentalService
  rentalAgency: CarRentalService;
  selectedBranch;

  constructor(private data: DataExchangeService, private service: RentalAgencyService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.rentalAgency = new CarRentalService("", "", "")
    //this.data.currentMessage.subscribe(message => this.message = message);
    let companyName;
    this.route.params.subscribe(params => companyName = params["name"]);

    this.service.getAgency(companyName).subscribe(
      res => {
        this.rentalAgency.name = res["name"],
        this.rentalAgency.description = res["description"],
        this.rentalAgency.logo = res["logo"],
        this.rentalAgency.branches = res["branches"]
      },
      err => {
        console.log(err);
      }
    )
  }

  sendCars(branch){
    this.selectedBranch = branch
    this.data.changeCars(branch.cars);
  }

}
