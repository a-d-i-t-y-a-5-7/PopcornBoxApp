import{ ComponentFixture} from '@angular/core/testing';
import { TestBed } from '@angular/core/testing';

import { FavouriteMediaComponent } from './favourite-media.component';

describe('FavouriteMediaComponent', () => {
  let component: FavouriteMediaComponent;
  let fixture: ComponentFixture<FavouriteMediaComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FavouriteMediaComponent]
    });
    fixture = TestBed.createComponent(FavouriteMediaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
