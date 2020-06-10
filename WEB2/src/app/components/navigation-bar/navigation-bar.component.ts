import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css'],
})
export class NavigationBarComponent implements OnInit {
  CurrentUser:any;
  Dialog: boolean;
  link:string;
  AviocompanyName:string;
  logInActive: boolean;
  constructor() {}

  ngOnInit(): void {
    this.CurrentUser = JSON.parse(sessionStorage.getItem("LoggedUser"))
    console.log(this.CurrentUser)
    this.Dialog = false;
    this.link = '/:ViewAvioCompany/'
    if(this.CurrentUser?.hasOwnProperty("OwnedAvioCompanies")){
      this.link += this.CurrentUser.OwnedAvioCompanies[0].Id
      this.AviocompanyName = this.CurrentUser.OwnedAvioCompanies[0].Name
    }
    this.logInActive = true;
  }
  showDialog(): void {
    this.Dialog = true;
  }
  hideDialog(): void {
    this.Dialog = false;
  }
  logInActivate(): void {
    this.logInActive = true;
  }
  signInActivate(): void {
    this.logInActive = !this.logInActive;
  }

  close(event:any):void {
    this.ngOnInit();
  }
  LogOut(){
    sessionStorage.clear();
    this.ngOnInit();
  }

}
