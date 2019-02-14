import { TestBed } from '@angular/core/testing';

import { TeamMetahumanService } from './team-metahuman.service';

describe('TeamMetahumanService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TeamMetahumanService = TestBed.get(TeamMetahumanService);
    expect(service).toBeTruthy();
  });
});
