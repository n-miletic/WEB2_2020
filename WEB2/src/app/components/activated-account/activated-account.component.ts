import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-activated-account',
  templateUrl: './activated-account.component.html',
  styleUrls: ['./activated-account.component.css']
})
export class ActivatedAccountComponent implements OnInit {
  link : string;
  constructor(private route: ActivatedRoute) {
    route.params.subscribe(params =>{this.link = params['link'];})
   }
  
  ngOnInit(): void {
    fetch(`/DiemApi/User/Activate/${this.link}`, {
      method: 'post',
      headers: {
          'Content-Type': 'application/json'
      }
  })
  console.log(this.link)
  }

}
