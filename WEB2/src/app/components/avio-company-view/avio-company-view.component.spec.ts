import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AvioCompanyViewComponent } from './avio-company-view.component';

describe('AvioCompanyViewComponent', () => {
  let component: AvioCompanyViewComponent;
  let fixture: ComponentFixture<AvioCompanyViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AvioCompanyViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AvioCompanyViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
