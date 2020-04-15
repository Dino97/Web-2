import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/entities/city/city';
import { CityService } from 'src/app/services/city/city.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CompanyService } from 'src/app/services/company/company.service';
import { Company } from 'src/app/entities/company/company';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  cities: City[];
  companies: Company[];
  flightForm: FormGroup;

  constructor(private cityService: CityService, private companyService: CompanyService) { }

  ngOnInit(): void {
    this.cities = this.cityService.mockedCities();
    this.companies = this.companyService.mockedCompanies();
    this.initForm();
  }

  initForm(){
    this.flightForm = new FormGroup({
      'origin': new FormControl(null, Validators.required),
      'destination': new FormControl(null, Validators.required),
      'from': new FormControl(null),
      'to': new FormControl(null),
      'passNum': new FormControl(1, Validators.required)
    })
  }

  onSubmit(){}
}
