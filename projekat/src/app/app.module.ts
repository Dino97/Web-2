import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/core/header/header.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent} from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { SmedAccComponent } from './components/smed-acc/smed-acc.component';
import { AirlineProfileComponent } from './components/airline-profile/airline-profile.component';
import { FriendListComponent } from './components/friend-list/friend-list.component';
import { PlaneSeatsComponent } from './components/plane-seats/plane-seats.component';
import { PartnersComponent } from './pages/partners/partners.component';
import { CitiesComponent } from './components/cities/cities.component';
import { RentResultsComponent } from './components/rent-results/rent-results.component';
import { FriendsComponent } from './pages/friends/friends.component';
import { HeroCompComponent } from './components/hero-comp/hero-comp.component';
import { RentPageComponent } from './pages/rent-page/rent-page.component';
import { FlightPageComponent } from './pages/flight-page/flight-page.component';
import { CarRentalServiceComponent } from './pages/car-rental-service/car-rental-service.component';
import { CarServiceDisplayComponent } from './components/car-service-display/car-service-display.component';
import { CompanyDisplayComponent } from './components/company-display/company-display.component';
import { RatingDisplayComponent } from './components/rating-display/rating-display.component';
import { UserService } from './services/user/user.service';
import { AuthInterceptor } from './auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    RegisterComponent,
    LoginComponent,
    ProfileComponent,
    SmedAccComponent,
    AirlineProfileComponent,
    FriendListComponent,
    PlaneSeatsComponent,
    PartnersComponent,
    CitiesComponent,
    RentResultsComponent,
    FriendsComponent,
    HeroCompComponent,
    RentPageComponent,
    FlightPageComponent,
    CarRentalServiceComponent,
    CarServiceDisplayComponent,
    CompanyDisplayComponent,
    RatingDisplayComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
