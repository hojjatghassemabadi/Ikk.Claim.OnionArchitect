import { TestBed } from '@angular/core/testing';

import { BachService } from './bach.service';

describe('BachService', () => {
  let service: BachService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BachService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
