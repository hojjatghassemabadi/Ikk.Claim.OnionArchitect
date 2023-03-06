import { TestBed } from '@angular/core/testing';

import { RegistercqdqrService } from './registercqdqr.service';

describe('RegistercqdqrService', () => {
  let service: RegistercqdqrService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegistercqdqrService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
