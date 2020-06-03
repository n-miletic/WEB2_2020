import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivatedAccountComponent } from './activated-account.component';

describe('ActivatedAccountComponent', () => {
  let component: ActivatedAccountComponent;
  let fixture: ComponentFixture<ActivatedAccountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActivatedAccountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivatedAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
