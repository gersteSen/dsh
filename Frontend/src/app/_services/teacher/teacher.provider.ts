import { isDevMode, Provider } from '@angular/core';
import { TeacherService } from './teacher.service';
import {
  TEACHER_SERVICE,
  TeacherServiceInterface,
} from './teacher.service.interface';
import { TeacherMockService } from './teacher.service.mock';

export const TeacherServiceProvider: Provider[] = [
  TeacherService,
  {
    provide: TEACHER_SERVICE,
    useFactory: (service: TeacherService): TeacherServiceInterface => {
      return isDevMode() ? new TeacherMockService() : service;
    },
    deps: [TeacherService],
  },
];
