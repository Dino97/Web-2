import { Component, OnInit } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-plane-seats',
  templateUrl: './plane-seats.component.html',
  styleUrls: ['./plane-seats.component.css']
})
export class PlaneSeatsComponent implements OnInit {

  @Input() takenSeats: number[];
  @Output() seatsSelectedEvent = new EventEmitter<number[]>();

  seats: number[];
  selectedSeats: string;


  
  constructor() {}

  ngOnInit(): void {
    this.seats = new Array(36);

    for (let index = 0; index < this.seats.length; index++)
      this.seats[index] = 0;
  }

  selectSeat(index, element) {

    if (this.seats[index] == 0) {
      this.seats[index] = 1;
      element.classList.add("selected");
    }
    else {
      this.seats[index] = 0;
      element.classList.remove("selected");
    }
    
    this.selectedSeats = "";

    for (let index = 0; index < this.seats.length; index++) {
      const element = this.seats[index];
      
      if (element == 1)
      {
        if (this.selectedSeats != "")
          this.selectedSeats += ", ";
        
        this.selectedSeats += ((index + 1));
      }
    }
  }

  emitSeats() {
    this.seatsSelectedEvent.emit(this.seats);
  }

  taken(i): boolean {
    return this.takenSeats.find(s => s == i) != undefined;
  }
}
