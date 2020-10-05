import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CarReservationService } from 'src/app/services/carReservation/car-reservation.service';

@Component({
  selector: 'app-confirm-reservation',
  templateUrl: './confirm-reservation.component.html',
  styleUrls: ['./confirm-reservation.component.css']
})
export class ConfirmReservationComponent implements OnInit {
  data
  
  constructor(public service: CarReservationService, private dialogRef: MatDialogRef<ConfirmReservationComponent>,
     private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.service.reservationInfo().subscribe(
      res => this.data = res,
      err => console.log(err)
    )
  }

  onMakeReservation(fromTime, toTime, price){
    this.service.reserve(fromTime, toTime, price).subscribe(
      res => {
        this.toastr.success("Your car has been reserved", "Success!");
        this.router.navigateByUrl("/cars");
      },
      err => console.log(err)
    )

    this.onCancel();
  }

  onCancel(){
    this.dialogRef.close()
  }

}
