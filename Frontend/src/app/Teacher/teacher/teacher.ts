import { CommonModule } from '@angular/common';
import { Component, computed, effect, inject, signal } from '@angular/core';
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
  #teacherStore = inject(TeacherStateStore);

  teacher = signal<TeacherDto | null>(null);
  avatarImage = computed<string>(
    () => this.teacher()?.avatar ?? 'images/placeholder.jpg',
  );

  constructor() {
    effect(() => {
      this.teacher.set(this.#teacherStore.selectedTeacher());
    });
  }
}
