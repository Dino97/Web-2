import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/services/company/company.service';
import { Airline } from 'src/app/entities/airline/airline';
import { CarRental } from 'src/app/entities/carRental/car-rental';

@Component({
  selector: 'app-partners',
  templateUrl: './partners.component.html',
  styleUrls: ['./partners.component.css']
})
export class PartnersComponent implements OnInit {
  airlines: Array<Airline>
  carRentalAgencies: Array<CarRental>

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.airlines = this.companyService.mockedAirlines();
    this.carRentalAgencies = this.companyService.mockedRentalAgencies();
  }

}
