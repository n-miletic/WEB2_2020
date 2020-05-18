import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rentacar',
  templateUrl: './rentacar.component.html',
  styleUrls: ['./rentacar.component.css']
})
export class RentacarComponent implements OnInit {

  
  pickUpTime = ['08:00', '09:00', '10:00', '11:00', '12:00', '13:00', 
                '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', 
                '20:00', '21:00', '22:00'];

  
  submitted = false;

  onSubmit() { this.submitted = true; }
  constructor() { }

  ngOnInit(): void {
  }

}
