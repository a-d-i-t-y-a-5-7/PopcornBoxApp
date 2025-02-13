import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientSongEditComponent } from './client-song-edit.component';

describe('ClientSongEditComponent', () => {
  let component: ClientSongEditComponent;
  let fixture: ComponentFixture<ClientSongEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClientSongEditComponent]
    });
    fixture = TestBed.createComponent(ClientSongEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
