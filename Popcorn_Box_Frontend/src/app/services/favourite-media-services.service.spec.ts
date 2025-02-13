import { TestBed } from '@angular/core/testing';

import { FavouriteMediaServicesService } from './favourite-media-services.service';

describe('FavouriteMediaServicesService', () => {
  let service: FavouriteMediaServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FavouriteMediaServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
