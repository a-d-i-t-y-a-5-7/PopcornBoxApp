import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientSongHomeComponent } from './client-song-home.component';

describe('ClientSongHomeComponent', () => {
  let component: ClientSongHomeComponent;
  let fixture: ComponentFixture<ClientSongHomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClientSongHomeComponent]
    });
    fixture = TestBed.createComponent(ClientSongHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
