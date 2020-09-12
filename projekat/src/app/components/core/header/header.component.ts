import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import JwtDecode from 'jwt-decode';
import { SocialAuthService } from 'angularx-social-login';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  username: string;

  constructor(private router: Router, private authService: SocialAuthService) { }

  ngOnInit(): void {
  }

  isRegistered(){
    let token = localStorage.getItem('token');
    if(token != undefined){
      this.username = JwtDecode(token).UserName;
      return true;
    } else {
      return false;
    }
  }

  isSysAdmin(){
    if(JwtDecode(localStorage.getItem('token')).role === "SystemAdmin"){
      return true;
    } else {
      return false;
    }
  }

  isRentACarAdmin(){
    if(JwtDecode(localStorage.getItem('token')).role === "RentACarAdmin"){
      return true;
    } else {
      return false;
    }
  }

  isRegularUser(){
    if(JwtDecode(localStorage.getItem('token')).role === "RegularUser"){
      return true;
    } else {
      return false;
    }
  }

  logOut(){
    this.username = ""; 
    if(JwtDecode(localStorage.getItem('token')).LoginType == "social"){
      this.authService.signOut();
    }
    localStorage.removeItem('token');
    this.router.navigateByUrl('/');
  }

  pathIsLogin(){
    if(location.pathname === "/login" || location.pathname === "/register"){
      return true;
    } else {
      return false;
    }
  }
}
