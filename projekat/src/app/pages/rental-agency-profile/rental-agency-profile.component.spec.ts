import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RentalAgencyProfileComponent } from './rental-agency-profile.component';

describe('RentalAgencyProfileComponent', () => {
  let component: RentalAgencyProfileComponent;
  let fixture: ComponentFixture<RentalAgencyProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RentalAgencyProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RentalAgencyProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
