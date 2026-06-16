import { Component, inject, input } from '@angular/core';
import { TeacherService } from '@app/_services/teacher/teacher.service';

@Component({
  selector: 'dsh-teacher',
  imports: [],
  templateUrl: './teacher.html',
  styleUrl: './teacher.css',
})
export class Teacher {
  #teacherService = inject(TeacherService);

  teacherId = input.required<string>();
}
