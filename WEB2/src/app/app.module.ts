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
@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    routingComponents,
    GoogleAutocompletePlacesComponent,
    FlightsViewComponent,
    ActivatedAccountComponent,
    UsersViewComponent
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