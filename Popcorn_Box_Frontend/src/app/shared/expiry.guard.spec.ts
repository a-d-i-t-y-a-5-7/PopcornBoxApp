import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { expiryGuard } from './expiry.guard';

describe('expiryGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => expiryGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
