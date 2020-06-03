import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GoogleAutocompletePlacesComponent } from './google-autocomplete-places.component';

describe('GoogleAutocompletePlacesComponent', () => {
  let component: GoogleAutocompletePlacesComponent;
  let fixture: ComponentFixture<GoogleAutocompletePlacesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [GoogleAutocompletePlacesComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GoogleAutocompletePlacesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
