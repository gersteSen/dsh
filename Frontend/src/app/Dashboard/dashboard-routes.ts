import { Routes } from '@angular/router';
import { SidebarWithRouterOutlet } from '@shared/_components/layout/sidebar-with-router-outlet/sidebar-with-router-outlet';
import { Page } from '../../_config/page';

export const DASHBOARD_ROUTES: Routes = [
  {
    path: '',
    component: SidebarWithRouterOutlet,
    children: [
      {
        path: '',
        redirectTo: 'Dashboard' as Page,
        pathMatch: 'full',
      },
      {
        path: 'Dashboard' as Page,
        loadComponent: () =>
          import('./dashboard/dashboard').then((d) => d.Dashboard),
      },
    ],
  },
];
