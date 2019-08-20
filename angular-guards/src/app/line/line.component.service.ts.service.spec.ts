import { TestBed } from '@angular/core/testing';

import { LineService } from './line.component.service.ts.service';

describe('Line.Component.Service.TsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LineService = TestBed.get(LineService);
    expect(service).toBeTruthy();
  });
});
