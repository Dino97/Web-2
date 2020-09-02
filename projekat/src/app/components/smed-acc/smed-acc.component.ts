import { Component, OnInit, Input } from '@angular/core';
import { SocialAuthService, FacebookLoginProvider, GoogleLoginProvider, SocialUser } from 'angularx-social-login';
import { UserService } from 'src/app/services/user/user.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-smed-acc',
  templateUrl: './smed-acc.component.html',
  styleUrls: ['./smed-acc.component.css']
})
export class SmedAccComponent implements OnInit {
  @Input() word: string;

  constructor(private authService: SocialAuthService, private service: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void { }

  logInWithSocial(platform: string): void{
    switch(platform){
      case "Facebook":
        platform = FacebookLoginProvider.PROVIDER_ID;
        break;
      case "Google":
        platform = GoogleLoginProvider.PROVIDER_ID;
    }

    this.authService.signIn(platform).then(
      user => {
        //console.log(platform + ' logged in user data is= ', user);
        let userData = {
          Provider: user.provider,
          IdToken: platform == "GOOGLE"? user.idToken : user.authToken,
          Email: user.email,
          UserName: "",
          FirstName: user.firstName,
          LastName: user.lastName,
        }

        this.service.socialLogin(userData).subscribe(
          (res: any) => {
            localStorage.setItem("token", res.token);
            this.router.navigateByUrl("/");
          },
          err => {
            console.log(err);
            this.toastr.error(err["message"], "Authentication failed");
            this.authService.signOut();
          }
        )
      },
      err => {
        console.log(err);
      }
    )
  }
}
