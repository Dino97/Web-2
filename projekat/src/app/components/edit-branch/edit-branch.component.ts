import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DataExchangeService } from 'src/app/services/data-exchange/data-exchange.service';
import { RentalAgencyService } from 'src/app/services/rentalAgency/rental-agency.service';
import { VehicleService } from 'src/app/services/vehicle/vehicle.service';
import { AddVehicleComponent } from '../add-vehicle/add-vehicle.component';


@Component({
  selector: 'app-edit-branch',
  templateUrl: './edit-branch.component.html',
  styleUrls: ['./edit-branch.component.css']
})
export class EditBranchComponent implements OnInit {
  cars;
  private agencyId: number;

  constructor(public service: RentalAgencyService, private data: DataExchangeService, private router: Router,
     private dialog: MatDialog, private vehicleService: VehicleService) { }

  ngOnInit(): void {
    this.data.currentMessage.subscribe(
      message => {
        this.agencyId = message.id;
        this.cars = message.cars;
      }
    );

    this.vehicleService.getCarUpdateEmitter().subscribe(emittedUpdate => {
      if(emittedUpdate !== undefined)
        this.cars.push(emittedUpdate);
    })
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
    this.vehicleService.branchId = this.agencyId;
    let dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    this.dialog.open(AddVehicleComponent, dialogConfig);
  }
}
