import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherAddInstrumentDialog } from './teacher-add-instrument-dialog';

describe('TeacherAddInstrumentDialog', () => {
  let component: TeacherAddInstrumentDialog;
  let fixture: ComponentFixture<TeacherAddInstrumentDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TeacherAddInstrumentDialog],
    }).compileComponents();

    fixture = TestBed.createComponent(TeacherAddInstrumentDialog);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
