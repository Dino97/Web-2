import { Component, OnInit } from '@angular/core';
import { ReservationService } from 'src/app/services/reservation/reservation.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-flight-invitations',
  templateUrl: './flight-invitations.component.html',
  styleUrls: ['./flight-invitations.component.css']
})
export class FlightInvitationsComponent implements OnInit {

  flightInvitations: any[];



  constructor(private reservationService: ReservationService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.reloadInvitations();
  }

  acceptInvitation(invitation) {
    this.reservationService.acceptInvitation(invitation).subscribe(_ => {
      this.reloadInvitations();
      this.toastr.success(`You accepted flight invite from ${invitation.from.firstName} ${invitation.from.lastName}.`, "Flight invite accepted");
    });
  }

  declineInvitation(invitation) {
    this.reservationService.declineInvitation(invitation).subscribe(_ => {
      this.reloadInvitations();
      this.toastr.success(`You declined flight invite from ${invitation.from.firstName} ${invitation.from.lastName}.`, "Flight invite declined");
    });
  }

  reloadInvitations() {
    this.reservationService.getFlightInvitations().subscribe((res: any[]) => this.flightInvitations = res);
  }
}
