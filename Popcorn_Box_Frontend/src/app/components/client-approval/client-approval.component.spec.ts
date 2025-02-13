import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientApprovalComponent } from './client-approval.component';

describe('ClientApprovalComponent', () => {
  let component: ClientApprovalComponent;
  let fixture: ComponentFixture<ClientApprovalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClientApprovalComponent]
    });
    fixture = TestBed.createComponent(ClientApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
