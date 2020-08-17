import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalServiceComponent } from './car-rental-service.component';

describe('CarRentalServiceComponent', () => {
  let component: CarRentalServiceComponent;
  let fixture: ComponentFixture<CarRentalServiceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarRentalServiceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarRentalServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
