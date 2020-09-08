import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  readonly BaseURI: string = "http://localhost:52482/api/"

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  formModel = this.fb.group({
    'Email': ['', [Validators.required, Validators.email]],
    'UserName': ['', [Validators.required]],
    'FirstName': ['', [Validators.required]],
    'LastName': ['', [Validators.required]],
    'City': [''],
    'PhoneNumber': [''],
    'CompanyName': ['', [Validators.required]],
    'CompanyType': ['', [Validators.required]],
    'CompanyDescription': ['', [Validators.required, Validators.maxLength(640)]],
    Passwords: this.fb.group({
      'Password': ['', [Validators.required, Validators.minLength(6)]],
      'ConfirmPass': ['', Validators.required]
    }, { validator: this.comparePasswords })
  });

  comparePasswords(fg: FormGroup){
    let confirmPassCtrl = fg.get('ConfirmPass');

    if(confirmPassCtrl.errors == null || 'passwordMissmatch' in confirmPassCtrl.errors){
      if(confirmPassCtrl.value != fg.get('Password').value){
        confirmPassCtrl.setErrors({passwordMissmatch: true})
      }else{
        confirmPassCtrl.setErrors(null)
      }
    }
  }

  addAdmin(){
    let body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FirstName: this.formModel.value.FirstName,
      LastName: this.formModel.value.LastName,
      Password: this.formModel.value.Passwords.Password,
      PhoneNumber: this.formModel.value.PhoneNumber,
      City: this.formModel.value.City,
      CompanyName: this.formModel.value.CompanyName,
      CompanyDescription: this.formModel.value.CompanyDescription,
      CompanyType: this.formModel.value.CompanyType
    }

    return this.http.post(this.BaseURI + "Admin/NewAdmin", body);
  }
}
