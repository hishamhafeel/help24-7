import { TestBed } from '@angular/core/testing';

import { HelperDetailsService } from './helper-details.service';

describe('HelperDetailsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HelperDetailsService = TestBed.get(HelperDetailsService);
    expect(service).toBeTruthy();
  });
});
