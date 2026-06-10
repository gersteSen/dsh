import { Component, computed, input } from '@angular/core';
import { TeacherDto } from '@generated/model/teacherDto';

@Component({
  selector: 'dsh-teacher-card',
  imports: [],
  templateUrl: './teacher-card.html',
  styleUrl: './teacher-card.css',
})
export class TeacherCard {
  teacher = input.required<TeacherDto>();
  avatarImage = computed<string>(
    () => this.teacher()?.avatar ?? 'images/placeholder.jpg',
  );
}
