import { Routes } from '@angular/router';
import { Page } from '../_config/page';
import { SidebarWithRouterOutlet } from './_shared/_components/layout/sidebar-with-router-outlet/sidebar-with-router-outlet';

export const routes: Routes = [
  {
    path: 'Login',
    title: 'DSH - Anmeldung',
    loadComponent: () => import('./Login/login-page').then((l) => l.LoginPage),
  },
  {
    path: 'Dashboard' as Page,
    title: 'DSH - Administration',
    component: SidebarWithRouterOutlet,
    children: [
      {
        path: 'Dashboard' as Page,
        title: 'DSH - Dashboard',
        loadChildren: () =>
          import('./Dashboard/dashboard-routes').then(
            (d) => d.DASHBOARD_ROUTES,
          ),
      },
      {
        path: 'Teachers' as Page,
        title: 'DSH - Teachers',
        loadChildren: () =>
          import('./Teacher/teacher-routes').then((t) => t.TEACHER_ROUTES),
      },
      {
        path: 'Settings' as Page,
        title: 'DSH - Settings',
        loadChildren: () =>
          import('./Settings/settings-routes').then((s) => s.SETTINGS_ROUTES),
      },
    ],
  },
  {
    path: '**',
    redirectTo: 'Login',
    pathMatch: 'full',
  },
];
