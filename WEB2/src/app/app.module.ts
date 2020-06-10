import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationBarComponent } from './components/navigation-bar/navigation-bar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LogInComponent } from './components/log-in/log-in.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { FlightsViewComponent } from './components/flights-view/flights-view.component';
import { GoogleAutocompletePlacesComponent } from './components/google-autocomplete-places/google-autocomplete-places.component';
import { GoogleMapsModule } from '@angular/google-maps'
import { FormsModule } from '@angular/forms';
import { ActivatedAccountComponent } from './components/activated-account/activated-account.component';
import { UsersViewComponent } from './components/users-view/users-view.component';
import { AdminUsersViewComponent } from './components/admin-users-view/admin-users-view.component';
import { AddAvioCompanyComponent } from './components/add-avio-company/add-avio-company.component';
import { AvioCompanyViewComponent } from './components/avio-company-view/avio-company-view.component';
import { RentCompanyViewComponent } from './components/rent-company-view/rent-company-view.component';
import { FlightCardComponent } from './flight-card/flight-card.component';
import { MyUserComponent } from './my-user/my-user.component';
@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    routingComponents,
    GoogleAutocompletePlacesComponent,
    FlightsViewComponent,
    ActivatedAccountComponent,
    UsersViewComponent,
    AdminUsersViewComponent,
    AddAvioCompanyComponent,
    AvioCompanyViewComponent,
    RentCompanyViewComponent,
    FlightCardComponent,
    MyUserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule, 
    GoogleMapsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }