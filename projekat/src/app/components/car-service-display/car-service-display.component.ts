import { Component, OnInit } from '@angular/core';
import { CarRentalService } from 'src/app/entities/cars/carRentalService/car-rental-service';
import { CompanyService } from 'src/app/services/company/company.service';
import { DataExchangeService } from 'src/app/services/data-exchange/data-exchange.service';
import { RentalAgencyService } from 'src/app/services/rentalAgency/rental-agency.service';

@Component({
  selector: 'app-car-service-display',
  templateUrl: './car-service-display.component.html',
  styleUrls: ['./car-service-display.component.css']
})
export class CarServiceDisplayComponent implements OnInit {
  carRentalServices;
  //message: CarRentalService;

  constructor(private service: RentalAgencyService, private data: DataExchangeService) { }

  ngOnInit(): void {
    this.service.getAgencies().subscribe(
      res => {
        this.carRentalServices = res
      }, 
      err =>{
        console.log(err);
      }
    )
    //this.data.currentMessage.subscribe(message => this.message = message);
  }

  /*sendMessage(newMessage: CarRentalService){
    this.data.changeMessage(newMessage);(click)=sendMessage(service)
  }*/

}
