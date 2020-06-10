import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReserveWindowComponent } from './reserve-window.component';

describe('ReserveWindowComponent', () => {
  let component: ReserveWindowComponent;
  let fixture: ComponentFixture<ReserveWindowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReserveWindowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReserveWindowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
