import {
  Component,
  computed,
  inject,
  input,
  resource,
  ResourceRef,
} from '@angular/core';
import { TEACHER_SERVICE } from '@app/_services/teacher/teacher.service.interface';
import { TeacherDto } from '@generated/model/models';

import { CommonModule } from '@angular/common';
import { Chip } from '@app/_shared/_components/chip/chip';
import { Icon } from '@app/_shared/_components/icon/icon';
import { firstValueFrom } from 'rxjs';
import { SexPipe } from '../../_utils/pipes/sex/sex-pipe';

@Component({
  selector: 'dsh-teacher',
  imports: [SexPipe, CommonModule, Icon, Chip],
  templateUrl: './teacher.html',
  styleUrl: './teacher.css',
})
export class Teacher {
  #teacherService = inject(TEACHER_SERVICE);

  teacherId = input.required<string>();

  teacherResouce: ResourceRef<TeacherDto | undefined> = resource({
    params: this.teacherId,
    loader: ({ params }) =>
      firstValueFrom(this.#teacherService.getTeacherById(params)),
  });

  teacher = computed<TeacherDto | undefined>(() => {
    if (this.teacherResouce.hasValue()) {
      return this.teacherResouce.value();
    }
    return undefined;
  });

  avatarImage = computed<string>(
    () => this.teacher()?.avatar ?? 'images/placeholder.jpg',
  );
}
