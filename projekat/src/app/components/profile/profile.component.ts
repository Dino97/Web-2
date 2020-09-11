import { Component, OnInit } from '@angular/core';
import { UserProfile } from './user-profile';
import { UserService } from 'src/app/services/user/user.service';
import { ToastrService } from 'ngx-toastr';
//import JwtDecode from 'jwt-decode';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  firstName: string;
  lastName: string;
  city: string;

  constructor(private service: UserService, private toastr: ToastrService) {}

  ngOnInit(): void {
    //this.role = JwtDecode(localStorage.getItem('token'))
    this.service.getUserProfile().subscribe((res: any) => { 
      this.firstName = res.firstName;
      this.lastName = res.lastName;
      this.city = res.city;
    });
  }

  updateProfile() {
    this.service.updateProfile({ firstName: this.firstName, lastName: this.lastName, city: this.city }).subscribe(_ => 
      this.toastr.success("User data updated.", "Saved")
    );
  }
}