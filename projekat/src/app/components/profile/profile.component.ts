import { Component, OnInit } from '@angular/core';
import { UserProfile } from './user-profile';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profile: UserProfile;

  constructor() {
    this.profile = new UserProfile("Dinulja", "Dino", "Tabakovic", "Novi Sad");
  }

  ngOnInit(): void {}
}