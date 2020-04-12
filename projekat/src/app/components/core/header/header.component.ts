import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  username: string;

  constructor() { }

  ngOnInit(): void {
    this.username = "";
  }

  isRegistered(){
    if(JSON.parse(localStorage.getItem('sessionUserRole')) != null){
      this.username = JSON.parse(localStorage.getItem('sessionUserName'));
      return true;
    } else {
      return false;
    }
  }

  logOut(){
    this.username = ""; 
    localStorage.removeItem('sessionUserName');
    localStorage.removeItem('sessionUserRole');
  }

  pathIsLogin(){
    if(location.pathname === "/login" || location.pathname === "/register"){
      return true;
    } else {
      return false;
    }
  }
}
