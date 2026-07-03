import { Routes } from '@angular/router';
import { Page } from '../_config/page';

export const routes: Routes = [
  {
    path: '',
    title: 'GrooveDesk | Harsch',
    children: [
      {
        path: '',
        redirectTo: 'Login' as Page,
        pathMatch: 'full',
      },
      {
        path: 'Login',
        title: 'GrooveDesk - Anmeldung',
        loadComponent: () =>
          import('./Login/login-page').then((l) => l.LoginPage),
      },
      {
        path: 'Dashboard' as Page,
        title: 'GrooveDesk - Dashboard',
        loadChildren: () =>
          import('./Dashboard/dashboard-routes').then(
            (d) => d.DASHBOARD_ROUTES,
          ),
      },
      {
        path: 'Teachers' as Page,
        title: 'GrooveDesk - Teachers',
        loadChildren: () =>
          import('./Teacher/teacher-routes').then((t) => t.TEACHER_ROUTES),
      },
      {
        path: 'Settings' as Page,
        title: 'GrooveDesk - Settings',
        loadChildren: () =>
          import('./Settings/settings-routes').then((s) => s.SETTINGS_ROUTES),
      },
      {
        path: '**',
        redirectTo: 'Dashboard' as Page,
      },
    ],
  },
];
