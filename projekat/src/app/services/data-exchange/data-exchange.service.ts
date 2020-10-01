import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { CarRentalAgency } from 'src/app/entities/cars/carRentalAgency/car-rental-agency';

@Injectable({
  providedIn: 'root'
})
export class DataExchangeService {
  private messageSource = new BehaviorSubject<number>(0);
  currentMessage = this.messageSource.asObservable();

  constructor() { }

  changeMessage(message: number){
    this.messageSource.next(message)
  }
}
