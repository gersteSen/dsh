import { Routes } from '@angular/router';
import { Page } from 'src/_config/page';
import { TeacherPage } from './teacher-page';

export const TEACHER_ROUTES: Routes = [
  {
    path: '',
    component: TeacherPage,
    children: [
      {
        path: '',
        redirectTo: 'Teachers' as Page,
        pathMatch: 'full',
      },
      {
        path: 'Teachers' as Page,
        title: 'GrooveDesk - Teachers',
        data: { showSubmenu: true, title: 'Lehrer' },
        loadComponent: () =>
          import('./teachers/teachers').then((t) => t.Teachers),
      },
      {
        path: ':teacherId',
        data: { showSubmenu: false, title: 'Lehrer' },
        loadComponent: () => import('./teacher/teacher').then((t) => t.Teacher),
      },
    ],
  },
];
