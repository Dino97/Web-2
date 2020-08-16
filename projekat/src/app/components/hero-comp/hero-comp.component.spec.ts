import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroCompComponent } from './hero-comp.component';

describe('HeroCompComponent', () => {
  let component: HeroCompComponent;
  let fixture: ComponentFixture<HeroCompComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeroCompComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
