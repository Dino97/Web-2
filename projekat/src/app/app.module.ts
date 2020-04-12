import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/core/header/header.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent} from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { SmedAccComponent } from './components/smed-acc/smed-acc.component';
import { MainComponent } from './pages/main/main.component';
import { AirlineProfileComponent } from './components/airline-profile/airline-profile.component';
import { FriendListComponent } from './components/friend-list/friend-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    RegisterComponent,
    LoginComponent,
    ProfileComponent,
    SmedAccComponent,
    MainComponent,
    AirlineProfileComponent,
    FriendListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
