import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnregisteredViewComponent } from './unregistered-view.component';

describe('UnregisteredViewComponent', () => {
  let component: UnregisteredViewComponent;
  let fixture: ComponentFixture<UnregisteredViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnregisteredViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnregisteredViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
