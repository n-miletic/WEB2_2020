import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { UnregisteredViewComponent } from './unregistered-view/unregistered-view.component';
import { SearchResultViewComponent } from './search-result-view/search-result-view.component';
import { CompanyViewComponent } from './company-view/company-view.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    UnregisteredViewComponent,
    SearchResultViewComponent,
    CompanyViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
