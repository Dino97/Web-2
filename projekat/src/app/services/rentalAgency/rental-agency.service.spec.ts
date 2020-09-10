import { TestBed } from '@angular/core/testing';

import { RentalAgencyService } from './rental-agency.service';

describe('RentalAgencyService', () => {
  let service: RentalAgencyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RentalAgencyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
