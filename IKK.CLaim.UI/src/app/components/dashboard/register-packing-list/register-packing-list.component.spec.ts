import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterPackingListComponent } from './register-packing-list.component';

describe('RegisterPackingListComponent', () => {
  let component: RegisterPackingListComponent;
  let fixture: ComponentFixture<RegisterPackingListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterPackingListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterPackingListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
