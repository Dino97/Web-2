import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CarRentalService } from 'src/app/entities/cars/carRentalService/car-rental-service';
import { CarRentalAgency } from 'src/app/entities/cars/carRentalAgency/car-rental-agency';
import { Car } from 'src/app/entities/cars/car/car';

@Injectable({
  providedIn: 'root'
})
export class DataExchangeService {
  private messageSource = new BehaviorSubject<CarRentalService>(new CarRentalService("default name", "default desc", "default pic"));
  currentMessage = this.messageSource.asObservable();

  constructor() { }

  changeMessage(message: CarRentalService){
    this.messageSource.next(message)
  }
}
