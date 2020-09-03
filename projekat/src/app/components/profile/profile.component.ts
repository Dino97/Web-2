import { Component, OnInit } from '@angular/core';
import { UserProfile } from './user-profile';
import { UserService } from 'src/app/services/user/user.service';
//import JwtDecode from 'jwt-decode';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  //role: string;
  profile: UserProfile;

  constructor(private service: UserService) {
    //this.profile = new UserProfile("Dinulja", "Dino", "Tabakovic", "Novi Sad");
  }

  ngOnInit(): void {
    //this.role = JwtDecode(localStorage.getItem('token'))
    this.service.getUserProfile().subscribe(
      res => {
        let user = res
        this.profile = new UserProfile(res["userName"], res["firstName"], res["lastName"], res["city"])
      },
      err => {
        console.log(err);
      }
    )
  }
}