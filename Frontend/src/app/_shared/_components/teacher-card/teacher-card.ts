import { Component, computed, inject, input } from '@angular/core';
import { Router } from '@angular/router';
import { TeacherStateStore } from '@app/Teacher/_store/teacher-state.store';
import { TeacherDto } from '@generated/model/teacherDto';
import { Chip } from '@shared/_components/chip/chip';
import { Icon } from '../icon/icon';

@Component({
  selector: 'dsh-teacher-card',
  imports: [Chip, Icon],
  templateUrl: './teacher-card.html',
  styleUrl: './teacher-card.css',
})
export class TeacherCard {
  readonly teacherStore = inject(TeacherStateStore);
  teacher = input.required<TeacherDto>();

  #router = inject(Router);
  avatarImage = computed<string>(
    () => this.teacher()?.avatar ?? 'images/placeholder.jpg',
  );

  protected navigateToTeacher() {
    this.teacherStore.setSelectedTeacher(this.teacher());

    this.#router.navigate([`./Teachers/${this.teacher()?.id}`], {
      queryParams: { teacherFullName: this.teacher()?.fullName },
    });
  }
}
