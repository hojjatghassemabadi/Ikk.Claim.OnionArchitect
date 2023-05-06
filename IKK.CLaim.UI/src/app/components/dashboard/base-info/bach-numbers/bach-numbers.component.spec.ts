import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BachNumbersComponent } from './bach-numbers.component';

describe('BachNumbersComponent', () => {
  let component: BachNumbersComponent;
  let fixture: ComponentFixture<BachNumbersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BachNumbersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BachNumbersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
