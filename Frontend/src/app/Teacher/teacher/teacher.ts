import { CommonModule } from '@angular/common';
import { Component, computed, inject } from '@angular/core';
import { TeacherDto } from '@generated/model/models';
import { TeacherStateStore } from '../_store/teacher-state.store';
import { TeacherDetail } from './teacher-detail/teacher-detail';

@Component({
  selector: 'dsh-teacher',
  imports: [CommonModule, TeacherDetail],
  templateUrl: './teacher.html',
  styleUrl: './teacher.css',
})
export class Teacher {
  store = inject(TeacherStateStore);

  teacher = computed<TeacherDto | null>(() => this.store.selectedTeacher());
  avatarImage = computed<string>(
    () => this.teacher()?.avatar ?? 'images/placeholder.jpg',
  );
}
