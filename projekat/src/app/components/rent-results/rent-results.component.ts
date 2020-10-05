import { Component, OnInit } from '@angular/core';
import { CarReservationService } from 'src/app/services/carReservation/car-reservation.service';
import { ToastrService } from 'ngx-toastr';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ConfirmReservationComponent } from '../confirm-reservation/confirm-reservation.component';
import JwtDecode from 'jwt-decode';

@Component({
  selector: 'app-rent-results',
  templateUrl: './rent-results.component.html',
  styleUrls: ['./rent-results.component.css']
})
export class RentResultsComponent implements OnInit {
  searchResults;

  constructor(public service: CarReservationService, private toastr: ToastrService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.service.getSearchClickEmitter().subscribe(emmitedResults => {
        if(emmitedResults !== undefined)
          this.searchResults = emmitedResults;
      }
    )
  }

  onReserve(hit){
    let token = localStorage.getItem('token');
    if(token != undefined && JwtDecode(token).role === "RegularUser"){
      this.service.toReserve = hit
      let dialogConfig = new MatDialogConfig();
      dialogConfig.disableClose = true;
      dialogConfig.autoFocus = true;
      this.dialog.open(ConfirmReservationComponent, dialogConfig);
    } else {
      this.toastr.error("You must be logged in to reserve", "Fail");
    }
  }
}
