import { TestBed } from '@angular/core/testing';

import { FavouriteSongService } from './favourite-song.service';

describe('FavouriteSongService', () => {
  let service: FavouriteSongService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FavouriteSongService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
