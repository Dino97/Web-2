import { Component, OnInit } from '@angular/core';
import { CarRentalService } from 'src/app/entities/cars/carRentalService/car-rental-service';
import { DataExchangeService } from 'src/app/services/data-exchange/data-exchange.service';

@Component({
  selector: 'app-car-rental-service',
  templateUrl: './car-rental-service.component.html',
  styleUrls: ['./car-rental-service.component.css']
})
export class CarRentalServiceComponent implements OnInit {
  message: CarRentalService

  constructor(private data: DataExchangeService) { }

  ngOnInit(): void {
    this.data.currentMessage.subscribe(message => this.message = message);
  }

}
