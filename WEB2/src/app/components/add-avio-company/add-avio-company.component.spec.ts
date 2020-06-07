import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAvioCompanyComponent } from './add-avio-company.component';

describe('AddAvioCompanyComponent', () => {
  let component: AddAvioCompanyComponent;
  let fixture: ComponentFixture<AddAvioCompanyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddAvioCompanyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAvioCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
