import { TestBed } from '@angular/core/testing';

import { HouseHoldService } from './house-hold.service';

describe('HouseHoldService', () => {
  let service: HouseHoldService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HouseHoldService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
