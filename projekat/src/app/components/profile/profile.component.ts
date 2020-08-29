import { Component, OnInit } from '@angular/core';
import { UserProfile } from './user-profile';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  profile: UserProfile;

  constructor(private service: UserService) {
    //this.profile = new UserProfile("Dinulja", "Dino", "Tabakovic", "Novi Sad");
  }

  ngOnInit(): void {
    this.service.getUserProfile().subscribe(
      res => {
        let user = res
        this.profile = new UserProfile(res["userName"], res["firstName"], res["lastName"], res["City"])
      },
      err => {
        console.log(err);
      }
    )
  }
}