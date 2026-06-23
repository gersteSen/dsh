import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateNewTeacherDialog } from './create-new-teacher-dialog';

describe('CreateNewTeacherDialog', () => {
  let component: CreateNewTeacherDialog;
  let fixture: ComponentFixture<CreateNewTeacherDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateNewTeacherDialog],
    }).compileComponents();

    fixture = TestBed.createComponent(CreateNewTeacherDialog);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
