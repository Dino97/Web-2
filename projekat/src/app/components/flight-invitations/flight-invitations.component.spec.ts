import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightInvitationsComponent } from './flight-invitations.component';

describe('FlightInvitationsComponent', () => {
  let component: FlightInvitationsComponent;
  let fixture: ComponentFixture<FlightInvitationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlightInvitationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightInvitationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
