import { TestBed } from '@angular/core/testing';

import { StudentGradeDetailService } from './student-grade-detail.service';

describe('StudentGradeDetailService', () => {
  let service: StudentGradeDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentGradeDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
