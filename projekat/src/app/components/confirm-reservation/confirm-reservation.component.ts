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
  selectedId : number;
  
  constructor(public service: CarReservationService, private dialogRef: MatDialogRef<ConfirmReservationComponent>,
     private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
    this.service.reservationInfo().subscribe(
      res => {
        this.data = res;
      },
      err => console.log(err)
    )
  }

  onMakeReservation(fromTime, toTime, price){
    let dropOffId = this.service.formModel.value.sameDrop ? this.service.toReserve.location.id : this.selectedId;
    this.service.reserve(fromTime, toTime, price, dropOffId).subscribe(
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
