import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DiscountDivAvioComponent } from './discount-div-avio.component';

describe('DiscountDivAvioComponent', () => {
  let component: DiscountDivAvioComponent;
  let fixture: ComponentFixture<DiscountDivAvioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DiscountDivAvioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DiscountDivAvioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
