import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UnregisteredViewComponent } from './components/unregistered-view/unregistered-view.component';
import { SearchResultViewComponent } from './components/search-result-view/search-result-view.component';
import { CompanyViewComponent } from './components/company-view/company-view.component';
import { FlightComponent } from './components/flight/flight.component';
import { RentacarComponent } from './components/rentacar/rentacar.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { SignInComponent } from './components/sign-in/sign-in.component';




const routes: Routes = [
  {
    path:"",
    component: UnregisteredViewComponent
  },
  {
    path:"flight",
    component: FlightComponent
  },
  {
    path:"rentacar",
    component: RentacarComponent
  },
  {
    path:"company/:id",
    component: CompanyViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [SearchResultViewComponent, FlightComponent, 
                                  RentacarComponent, UnregisteredViewComponent, 
                                  LogInComponent, SignInComponent, 
                                  CompanyViewComponent]