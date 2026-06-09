import { isDevMode, Provider } from '@angular/core';
import { TeacherService } from './teacher.service';
import { TEACHER_SERVICE } from './teacher.service.interface';
import { TeacherMockService } from './teacher.service.mock';

export const TeacherServiceProvider: Provider[] = [
  TeacherService,
  {
    provide: TEACHER_SERVICE,
    useFactory: (service: TeacherService) => {
      return isDevMode() ? new TeacherMockService() : service;
    },
    deps: [TeacherService],
  },
];
