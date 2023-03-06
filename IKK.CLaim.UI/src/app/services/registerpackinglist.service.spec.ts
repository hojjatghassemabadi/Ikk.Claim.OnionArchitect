import { TestBed } from '@angular/core/testing';

import { RegisterpackinglistService } from './registerpackinglist.service';

describe('RegisterpackinglistService', () => {
  let service: RegisterpackinglistService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegisterpackinglistService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
