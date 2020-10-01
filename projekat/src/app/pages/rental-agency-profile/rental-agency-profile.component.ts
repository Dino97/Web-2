import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataExchangeService } from 'src/app/services/data-exchange/data-exchange.service';
import { RentalAgencyService } from 'src/app/services/rentalAgency/rental-agency.service';

@Component({
  selector: 'app-rental-agency-profile',
  templateUrl: './rental-agency-profile.component.html',
  styleUrls: ['./rental-agency-profile.component.css']
})
export class RentalAgencyProfileComponent implements OnInit {
  branches;

  constructor(private service: RentalAgencyService, private data: DataExchangeService, private router: Router) { }

  ngOnInit(): void {
    this.service.getBranches().subscribe(
      res => {
        this.branches = res;
      },
      err => {
        console.log(err);
      }
    )

    this.service.getBranchUpdateEmitter().subscribe(emittedUpdate => {
      if(emittedUpdate !== undefined)
        this.branches = emittedUpdate;
    })
  }

  sendMessage(newMessage){
    this.service.formModel.setValue({
      Country: newMessage.location.country,
      City: newMessage.location.city,
      Address: newMessage.location.adress,
      WorksFrom: this.time2String(newMessage.workTimeFrom),
      WorksTo: this.time2String(newMessage.workTimeTo),
      ContactNumber: newMessage.contactNumber,
      NearAirport: newMessage.nearAirpot ? "true" : "false"
    });
    this.data.changeMessage(newMessage.id);
  }

  time2String(messageTime): string{
    let dateTime: Date = new Date(messageTime);
    let stringTime: string = "";

    let hours = dateTime.getHours();

    if(hours < 10){
      stringTime += "0";
    }

    stringTime += hours.toString() + ":" + dateTime.getMinutes().toString();

    return stringTime;
  }
}
