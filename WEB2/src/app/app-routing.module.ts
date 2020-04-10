import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UnregisteredViewComponent } from './unregistered-view/unregistered-view.component';
import { SearchResultViewComponent } from './search-result-view/search-result-view.component';


const routes: Routes = [
  {
    path:"",
    component: UnregisteredViewComponent
  },
  {
    path:"flights",
    component: SearchResultViewComponent
  },
  {
    path:"rentacar",
    component: SearchResultViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [SearchResultViewComponent, UnregisteredViewComponent]