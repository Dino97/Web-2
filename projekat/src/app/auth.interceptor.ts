import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators'
import { Router } from '@angular/router';
import { SocialAuthService } from 'angularx-social-login';
import JwtDecode from 'jwt-decode';

@Injectable()
export class AuthInterceptor implements HttpInterceptor{

    constructor(private router: Router, private authService: SocialAuthService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>{
        if(localStorage.getItem('token') != null){
            const clonedReq = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + localStorage.getItem("token"))
            });
            return next.handle(clonedReq).pipe(
                tap(
                    succ => { },
                    err => { 
                        if(err.status == 401){
                            if(JwtDecode(localStorage.getItem('token')).LoginType == "social"){
                                this.authService.signOut();
                              }
                            localStorage.removeItem('token');
                            this.router.navigateByUrl('/login');
                        }
                    }
                )
            )
        } else {
            return next.handle(req.clone());
        }    
    }
}