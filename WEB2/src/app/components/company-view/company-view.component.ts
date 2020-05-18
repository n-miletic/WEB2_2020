import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-company-view',
  templateUrl: './company-view.component.html',
  styleUrls: ['./company-view.component.css']
})
export class CompanyViewComponent implements OnInit {

  id:string;

  constructor(private route: ActivatedRoute) {
    route.params.subscribe(params =>{this.id = params['id'];})
   }

  
  ngOnInit(): void {
  }

}
