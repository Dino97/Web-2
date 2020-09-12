import { Component, OnInit } from '@angular/core';
import { RentalAgencyService } from 'src/app/services/rentalAgency/rental-agency.service';

@Component({
  selector: 'app-rental-agency-profile',
  templateUrl: './rental-agency-profile.component.html',
  styleUrls: ['./rental-agency-profile.component.css']
})
export class RentalAgencyProfileComponent implements OnInit {
  branches;

  constructor(private service: RentalAgencyService) { }

  ngOnInit(): void {
    this.service.getBranches().subscribe(
      res => {
        this.branches = res;
      },
      err => {
        console.log(err);
      }
    )
  }

}
