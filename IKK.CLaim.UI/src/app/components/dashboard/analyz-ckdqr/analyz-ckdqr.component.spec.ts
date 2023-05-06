import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnalyzCKDQRComponent } from './analyz-ckdqr.component';

describe('AnalyzCKDQRComponent', () => {
  let component: AnalyzCKDQRComponent;
  let fixture: ComponentFixture<AnalyzCKDQRComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnalyzCKDQRComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnalyzCKDQRComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
