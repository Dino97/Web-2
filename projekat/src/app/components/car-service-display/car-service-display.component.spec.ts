import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarServiceDisplayComponent } from './car-service-display.component';

describe('CarServiceDisplayComponent', () => {
  let component: CarServiceDisplayComponent;
  let fixture: ComponentFixture<CarServiceDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarServiceDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarServiceDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
