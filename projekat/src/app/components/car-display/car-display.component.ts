import { Component, OnInit } from '@angular/core';
import { DataExchangeService } from 'src/app/services/data-exchange/data-exchange.service';

@Component({
  selector: 'app-car-display',
  templateUrl: './car-display.component.html',
  styleUrls: ['./car-display.component.css']
})
export class CarDisplayComponent implements OnInit {
  cars;

  constructor(private dataExchange: DataExchangeService) { }

  ngOnInit(): void {
    this.dataExchange.currentCars.subscribe(
      sentCars => this.cars = sentCars
    )
  }

}
