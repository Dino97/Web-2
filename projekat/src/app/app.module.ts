import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { SocialLoginModule, SocialAuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider, FacebookLoginProvider } from 'angularx-social-login';

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
import { FlightSearchComponent } from './components/flight-search/flight-search.component';
import { UserService } from './services/user/user.service';
import { TravelHistoryComponent } from './components/travel-history/travel-history.component';
import { NewFlightComponent } from './components/new-flight/new-flight.component';
import { AuthInterceptor } from './auth.interceptor';
import { NewAdminComponent } from './components/new-admin/new-admin.component';
import { FlightReservationComponent } from './pages/flight-reservation/flight-reservation.component';
import { FlightInvitationsComponent } from './components/flight-invitations/flight-invitations.component';
import { RentalAgencyProfileComponent } from './pages/rental-agency-profile/rental-agency-profile.component';
import { AddBranchComponent } from './components/add-branch/add-branch.component';
import { AirlineComponent } from './pages/airline/airline.component';

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
    FlightSearchComponent,
    TravelHistoryComponent,
    NewFlightComponent,
    NewAdminComponent,
    FlightReservationComponent,
    FlightInvitationsComponent,
    RentalAgencyProfileComponent,
    AddBranchComponent,
    AirlineComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    SocialLoginModule
  ],
  providers: [UserService, 
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  },
  {
    provide: "SocialAuthServiceConfig",
    useValue: {
      autoLogin: false,
      providers: [
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider('978851679667-ojajf92olvnbupcd0ib4cvp1i4sl5uu4.apps.googleusercontent.com')
        },
        {
          id: FacebookLoginProvider.PROVIDER_ID,
          provider: new FacebookLoginProvider('803053426901714')
        }
      ]} as SocialAuthServiceConfig
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
