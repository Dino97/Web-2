import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import JwtDecode from 'jwt-decode';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  username: string;

  constructor(private router: Router) { }

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

  logOut(){
    this.username = ""; 
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
