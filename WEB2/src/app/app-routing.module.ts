import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UnregisteredViewComponent } from './unregistered-view/unregistered-view.component';
import { SearchResultViewComponent } from './search-result-view/search-result-view.component';
import { CompanyViewComponent } from './company-view/company-view.component';
import { FlightComponent } from './flight/flight.component';
import { RentacarComponent } from './rentacar/rentacar.component';



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
export const routingComponents = [SearchResultViewComponent, FlightComponent, RentacarComponent, UnregisteredViewComponent, CompanyViewComponent]