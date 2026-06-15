import { Routes } from '@angular/router';
import { TeacherPage } from '@app/Teacher/teacher';

export const TEACHER_ROUTES: Routes = [
  {
    path: '',
    component: TeacherPage,
    children: [
      {
        path: '',
        pathMatch: 'full',
        loadComponent: () =>
          import('./teachers/teachers').then((t) => t.Teachers),
      },
      {
        path: ':teacherId',
        loadComponent: () => import('./teacher/teacher').then((t) => t.Teacher),
      },
    ],
  },
];
