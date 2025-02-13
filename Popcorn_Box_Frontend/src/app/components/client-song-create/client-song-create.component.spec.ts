import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientSongCreateComponent } from './client-song-create.component';

describe('ClientSongCreateComponent', () => {
  let component: ClientSongCreateComponent;
  let fixture: ComponentFixture<ClientSongCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClientSongCreateComponent]
    });
    fixture = TestBed.createComponent(ClientSongCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
