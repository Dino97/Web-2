import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.initForm()
  }

  initForm(){
    this.registerForm = new FormGroup({
      'emailControl': new FormControl(null, Validators.required),
      'username': new FormControl(null, Validators.required),
      'password': new FormControl(null, Validators.required),
      'confirmPass': new FormControl(null, Validators.required),
      'name': new FormControl(null),
      'lastName': new FormControl(null),
      'city': new FormControl(null),
      'phone': new FormControl(null)
    })
  }

  onSubmit(){}
}
