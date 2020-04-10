import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SmedAccComponent } from './smed-acc.component';

describe('SmedAccComponent', () => {
  let component: SmedAccComponent;
  let fixture: ComponentFixture<SmedAccComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SmedAccComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SmedAccComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
