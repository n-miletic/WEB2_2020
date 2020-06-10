import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RentCompanyViewComponent } from './rent-company-view.component';

describe('RentCompanyViewComponent', () => {
  let component: RentCompanyViewComponent;
  let fixture: ComponentFixture<RentCompanyViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RentCompanyViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RentCompanyViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
