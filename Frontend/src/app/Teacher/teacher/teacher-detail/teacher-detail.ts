import { CommonModule } from '@angular/common';
import { Component, input } from '@angular/core';
import { Chip } from '@app/_shared/_components/chip/chip';
import { IconButton } from '@app/_shared/_components/icon-button/icon-button';
import { TeacherDto } from '@generated/model/models';

@Component({
  selector: 'dsh-teacher-detail',
  imports: [CommonModule, IconButton, Chip],
  templateUrl: './teacher-detail.html',
  styleUrl: './teacher-detail.css',
})
export class TeacherDetail {
  teacher = input<TeacherDto | null>(null);
}
