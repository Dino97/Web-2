import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.initForm()
  }

  private initForm(){
    this.loginForm = new FormGroup({
      'username': new FormControl(null, Validators.required),
      'password': new FormControl(null, Validators.required)
    });
  }

  onSubmit(){
    let registered = false;

    if(this.loginForm.value.username === "user" && this.loginForm.value.password === "user"){
      localStorage.setItem('sessionUserRole', JSON.stringify('USER'));
      registered = true;
    } else if (this.loginForm.value.username === "admin" && this.loginForm.value.password === "admin"){
      localStorage.setItem('sessionUserRole', JSON.stringify('ADMIN'));
      registered = true;
    } else if (this.loginForm.value.username === "adminRent" && this.loginForm.value.password === "adminRent"){
      localStorage.setItem('sessionUserRole', JSON.stringify('RENT ADMIN'));
      registered = true;
    } else if(this.loginForm.value.username === "adminFlight" && this.loginForm.value.password === "userFlight"){
      localStorage.setItem('sessionUserRole', JSON.stringify('FLIGHT ADMIN'));
      registered = true;
    }

    if(registered){
      localStorage.setItem('sessionUserName', JSON.stringify(this.loginForm.value.username));
    }
  }
}
