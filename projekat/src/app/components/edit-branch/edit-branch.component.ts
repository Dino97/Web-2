import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DataExchangeService } from 'src/app/services/data-exchange/data-exchange.service';
import { RentalAgencyService } from 'src/app/services/rentalAgency/rental-agency.service';
import { AddVehicleComponent } from '../add-vehicle/add-vehicle.component';


@Component({
  selector: 'app-edit-branch',
  templateUrl: './edit-branch.component.html',
  styleUrls: ['./edit-branch.component.css']
})
export class EditBranchComponent implements OnInit {
  
  private agencyId: number;
  /*formModel = {
    Address: '',
    WorksFrom: '',
    WorksTo: '',
    NearAirport: '',
    Contact: ''
  }*/

  constructor(public service: RentalAgencyService, private data: DataExchangeService, private router: Router, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.data.currentMessage.subscribe(
      message => {
        this.agencyId = message;
      }
    );
  }

  onSubmit(){
    this.service.updateBranch(this.agencyId).subscribe(
      res => {
        this.service.getBranches().subscribe(
          resBranches => {
            this.service.getBranchUpdateEmitter().emit(resBranches)
          }
        );
      },
      err => console.log(err)
    )
  }

  onAddVehicle(){
    this.dialog.open(AddVehicleComponent);
  }
}
