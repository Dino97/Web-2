import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { SocialUser } from 'angularx-social-login';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly BaseURI: string = "http://localhost:52482/api/"

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  formModel = this.fb.group({
    'Email': ['', [Validators.required, Validators.email]],
    'UserName': ['', [Validators.required]],
    'FirstName': ['', [Validators.required]],
    'LastName': ['', [Validators.required]],
    'City': [''],
    'PhoneNumber': [''],
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

  register(){
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FirstName: this.formModel.value.FirstName,
      LastName: this.formModel.value.LastName,
      Password: this.formModel.value.Passwords.Password,
      PhoneNumber: this.formModel.value.PhoneNumber,
      City: this.formModel.value.City
    }
    
    return this.http.post(this.BaseURI + 'User/Register', body);
  }

  login(formData){
    return this.http.post(this.BaseURI + "User/Login", formData);
  }

  getUserProfile(){
    //let tokenHeader = new HttpHeaders({"Authorization": "Bearer " + localStorage.getItem("token")});
    return this.http.get(this.BaseURI + "Profile"/*, {headers: tokenHeader}*/);
  }

  socialLogin(userData){
    return this.http.post(this.BaseURI + "User/SocialLogin", userData);
  }
}
