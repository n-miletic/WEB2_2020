import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css']
})
export class NavigationBarComponent implements OnInit {

  Dialog:boolean;
  logInActive:boolean;
  constructor() { }

  ngOnInit(): void {
    this.Dialog = false;
    this.logInActive = true;
  }
  showDialog():void{
    this.Dialog = true;
    console.log("super")
  }
  hideDialog():void{
    this.Dialog = false;
  }
  logInActivate():void{
    this.logInActive = true;
  }
  signInActivate():void{
    this.logInActive = !this.logInActive;
  }

}
