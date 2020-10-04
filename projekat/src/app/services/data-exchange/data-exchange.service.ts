import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataExchangeService {
  private messageSource = new BehaviorSubject<any>(0);
  currentMessage = this.messageSource.asObservable();

  messageCars = new BehaviorSubject<any>(null);
  currentCars = this.messageCars.asObservable();

  constructor() { }

  changeMessage(message){
    this.messageSource.next(message)
  }

  changeCars(cars){
    this.messageCars.next(cars);
  }
}
