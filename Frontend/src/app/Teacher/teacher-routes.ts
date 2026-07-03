import { Routes } from '@angular/router';
import { SidebarWithRouterOutlet } from '@app/_shared/_components/layout/sidebar-with-router-outlet/sidebar-with-router-outlet';
import { Page } from 'src/_config/page';

export const TEACHER_ROUTES: Routes = [
  {
    path: '',
    component: SidebarWithRouterOutlet,
    children: [
      {
        path: '',
        redirectTo: 'Teachers' as Page,
        pathMatch: 'full',
      },
      {
        path: 'Teachers' as Page,
        data: { showSubmenu: false, title: 'GrooveDesk - Teachers' },
        loadComponent: () =>
          import('./teachers/teachers').then((t) => t.Teachers),
      },
      {
        path: ':teacherId',
        data: { showSubmenu: false, title: 'GrooveDesk - Teacher' },
        loadComponent: () => import('./teacher/teacher').then((t) => t.Teacher),
      },
    ],
  },
];
