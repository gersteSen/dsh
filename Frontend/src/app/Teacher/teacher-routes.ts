import { Routes } from '@angular/router';

export const TEACHER_ROUTES: Routes = [
  {
    path: '',
    loadComponent: () => import('./teachers/teachers').then((t) => t.Teachers),
  },
];
