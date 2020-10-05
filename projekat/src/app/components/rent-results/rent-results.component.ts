import { Component, OnInit } from '@angular/core';
import { CarReservationService } from 'src/app/services/carReservation/car-reservation.service';

@Component({
  selector: 'app-rent-results',
  templateUrl: './rent-results.component.html',
  styleUrls: ['./rent-results.component.css']
})
export class RentResultsComponent implements OnInit {
  searchResults;

  constructor(public service: CarReservationService) { }

  ngOnInit(): void {
    this.service.getSearchClickEmitter().subscribe(emmitedResults => {
        if(emmitedResults !== undefined)
          this.searchResults = emmitedResults;
      }
    )
  }

}
