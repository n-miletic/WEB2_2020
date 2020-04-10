import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UnregisteredViewComponent } from './unregistered-view/unregistered-view.component';


const routes: Routes = [
  {
    path:"",
    component: UnregisteredViewComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
