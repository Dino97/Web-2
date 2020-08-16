import { Component, OnInit } from '@angular/core';
import { CarRentalService } from 'src/app/entities/cars/carRentalService/car-rental-service';
import { CompanyService } from 'src/app/services/company/company.service';

@Component({
  selector: 'app-rent-page',
  templateUrl: './rent-page.component.html',
  styleUrls: ['./rent-page.component.css']
})
export class RentPageComponent implements OnInit {
  carRentalServices: Array<CarRentalService>;

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.carRentalServices = this.companyService.getRentalServices()
  }

}
