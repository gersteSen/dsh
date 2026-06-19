import { Component, inject } from '@angular/core';
import { TeacherCard } from '@shared/_components/teacher-card/teacher-card';
import { TeacherStateStore } from '@app/Teacher/_store/teacher-state.store';
import { Loader } from '@shared/_components/loader/loader';

@Component({
  selector: 'dsh-teachers',
  imports: [TeacherCard, Loader],
  templateUrl: './teachers.html',
  styleUrl: './teachers.css',
})
export class Teachers {
  store = inject(TeacherStateStore);

  constructor() {
    this.store.getAllTeachersRXJS();
  }
}
