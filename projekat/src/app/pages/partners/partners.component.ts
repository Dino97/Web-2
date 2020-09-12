import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/services/company/company.service';
import { Airline } from 'src/app/entities/airline/airline';
import { CarRentalService } from 'src/app/entities/cars/carRentalService/car-rental-service';


@Component({
  selector: 'app-partners',
  templateUrl: './partners.component.html',
  styleUrls: ['./partners.component.css']
})
export class PartnersComponent implements OnInit {
  airlines: Array<Airline>
  carRentalServices: Array<CarRentalService>

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.airlines = this.companyService.getAirlines();
  }

}
