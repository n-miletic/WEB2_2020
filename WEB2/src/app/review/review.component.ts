import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { StarRatingComponent } from 'ng-starrating';
@Component({
  selector: 'review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.css']
})
export class ReviewComponent implements OnInit {
  Stars;
  rating;
  comment;
  @Input() doneReview:any;
  @Input() pendingReview:any;
  @Output() ReviewDone = new EventEmitter();
  constructor() { }
  onRate($event:{oldValue:number, newValue:number, starRating:StarRatingComponent}){
    this.Stars = $event.newValue;
  }
  emitRating(){
    let toEmit = {
      Rating: this.Stars,
      Comment: this.comment,
      ReservationId: this.pendingReview.Id
    }
    this.ReviewDone.emit(toEmit)
  }
  ngOnInit(): void {
    console.log(this.doneReview)
  }

}
