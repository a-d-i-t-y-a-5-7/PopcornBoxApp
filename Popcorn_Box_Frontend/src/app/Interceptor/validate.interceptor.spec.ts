import { TestBed } from '@angular/core/testing';

import { ValidateInterceptor } from './validate.interceptor';

describe('ValidateInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      ValidateInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: ValidateInterceptor = TestBed.inject(ValidateInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
