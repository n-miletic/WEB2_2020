import {
  Component,
  ViewChild,
  OnInit,
  EventEmitter,
  AfterViewInit,
  Input,
  Output,
  ViewEncapsulation,
} from '@angular/core';

import { MapInfoWindow, MapMarker, GoogleMap } from '@angular/google-maps';
@Component({
  selector: 'AutocompleteComponent',
  templateUrl: './google-autocomplete-places.component.html',
  styleUrls: [
    './google-autocomplete-places.component.css',
    '../../components/flights-view/flights-view.component.css',
  ],
  encapsulation: ViewEncapsulation.None,
})
export class GoogleAutocompletePlacesComponent
  implements OnInit, AfterViewInit {
  @Input() adressType: string;
  @Input() inputName: string;
  @Output() setAddress: EventEmitter<any> = new EventEmitter();
  @ViewChild('addresstext') addresstext: any;

  autocompleteInput: string;
  queryWait: boolean;

  constructor() {}

  ngOnInit(): void {}
  ngAfterViewInit() {
    this.addresstext.nativeElement.name = this.inputName;

    this.getPlaceAutocomplete();
  }
  private getPlaceAutocomplete() {
    const autocomplete = new google.maps.places.Autocomplete(
      this.addresstext.nativeElement,
      {
        types: [this.adressType], // 'establishment' / 'address' / 'geocode'
      }
    );

    google.maps.event.addListener(autocomplete, 'place_changed', () => {
      
      const place = autocomplete.getPlace();
      if(place.types.includes('airport')){
        console.log('gud')
        this.invokeEvent(place);
      }
    });
  }

  invokeEvent(place: Object) {
    let toEmit = [this.inputName, place];
    this.setAddress.emit(toEmit);
  }
}
