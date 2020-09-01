import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { RegisterComponent } from './components/register/register.component';
import { AirlineProfileComponent } from './components/airline-profile/airline-profile.component';
import { PartnersComponent } from './pages/partners/partners.component';
import { CitiesComponent } from './components/cities/cities.component';
import { RentResultsComponent } from './components/rent-results/rent-results.component';
import { FriendsComponent } from './pages/friends/friends.component';
import { FlightPageComponent } from './pages/flight-page/flight-page.component';
import { RentPageComponent } from './pages/rent-page/rent-page.component';
import { CarRentalServiceComponent } from './pages/car-rental-service/car-rental-service.component';
import { FlightSearchComponent } from './components/flight-search/flight-search.component';
import { TravelHistoryComponent } from './components/travel-history/travel-history.component';
import { NewFlightComponent } from './components/new-flight/new-flight.component';


const routes: Routes = [
  { path: "", redirectTo: "partners", pathMatch: "full"},
  { path: "login", component: LoginComponent },
  { path: "profile", component: ProfileComponent },
  { path: "airprofile", component: AirlineProfileComponent },
  { path: "register", component: RegisterComponent },
  { path: "partners", component: PartnersComponent },
  /*{ path: "cars", component: MainComponent, children: [
    { path: "", component: CitiesComponent },
    { path: "results", component: RentResultsComponent }
  ]}*/
  { path: "rentalService", component: CarRentalServiceComponent},
  { path: "cars", component: RentPageComponent },
  { path: "flights", component: FlightPageComponent },
  { path: "friends", component: FriendsComponent },
  { path: "flightsearch", component: FlightSearchComponent },
  { path: "home", component: TravelHistoryComponent },
  { path: "newflight", component: NewFlightComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
