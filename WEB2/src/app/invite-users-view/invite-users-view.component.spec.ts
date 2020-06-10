import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InviteUsersViewComponent } from './invite-users-view.component';

describe('InviteUsersViewComponent', () => {
  let component: InviteUsersViewComponent;
  let fixture: ComponentFixture<InviteUsersViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InviteUsersViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InviteUsersViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
