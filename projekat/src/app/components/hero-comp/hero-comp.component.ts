import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CarReservationService } from 'src/app/services/carReservation/car-reservation.service';

@Component({
  selector: 'app-hero-comp',
  templateUrl: './hero-comp.component.html',
  styleUrls: ['./hero-comp.component.css']
})
export class HeroCompComponent implements OnInit {
  image: string;

  constructor(public service: CarReservationService, private router: Router) { }

  ngOnInit(): void {
    this.image = "../../../assets/images/" + location.pathname.split('/')[1] + "Hero.jpg"
    this.service.formModel.reset();
  }

  onSubmit(){
    this.service.search().subscribe(
      res => {
        this.service.getSearchClickEmitter().emit(res);
      },
      err => console.log(err)
    )
    this.router.navigateByUrl("/cars/results");
  }
}
