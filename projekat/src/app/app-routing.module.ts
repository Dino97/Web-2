import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { RegisterComponent } from './components/register/register.component';
import { MainComponent } from './pages/main/main.component';
import { AirlineProfileComponent } from './components/airline-profile/airline-profile.component';
import { PartnersComponent } from './pages/partners/partners.component';
import { CitiesComponent } from './components/cities/cities.component';
import { RentResultsComponent } from './components/rent-results/rent-results.component';


const routes: Routes = [
  { path: "", redirectTo: "flights", pathMatch: "full"},
  { path: "login", component: LoginComponent },
  { path: "profile", component: ProfileComponent },
  { path: "airprofile", component: AirlineProfileComponent },
  { path: "register", component: RegisterComponent },
  { path: "partners", component: PartnersComponent},
  { path: "cars", component: MainComponent, children: [
    { path: "", component: CitiesComponent},
    { path: "results", component: RentResultsComponent}
  ]},
  { path: "flights", component: MainComponent, children: [
    { path: "", component: CitiesComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
