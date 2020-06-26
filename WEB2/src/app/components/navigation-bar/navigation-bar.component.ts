import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user-service.service';
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
  constructor(public userService:UserService) {}

  ngOnInit(): void {
    this.Dialog = false;
    this.link = '/:ViewAvioCompany/'
    if(this.userService.CurrentUser?.hasOwnProperty("OwnedAvioCompanies")){
      this.link += this.userService.CurrentUser.OwnedAvioCompanies[0].Id
      this.AviocompanyName = this.userService.CurrentUser.OwnedAvioCompanies[0].Name
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
    this.userService.logOut();
    this.ngOnInit();
  }

}
