import { Component, OnInit } from '@angular/core';
import { Flight } from "../../entities/flight/flight"
import { Airport } from 'src/app/entities/airport/airport';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
}