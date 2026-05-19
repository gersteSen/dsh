import { Routes } from '@angular/router';
import { Page } from '../_config/page';
import { SidebarWithRouterOutlet } from './_shared/_components/layout/sidebar-with-router-outlet/sidebar-with-router-outlet';

export const routes: Routes = [
  {
    path: '',
    title: 'DSH - Administration',
    component: SidebarWithRouterOutlet,
    children: [
      {
        path: '',
        redirectTo: 'Dashboard' as Page,
        pathMatch: 'full',
      },
      {
        path: 'Dashboard' as Page,
        title: 'DSH - Dashboard',
        loadChildren: () =>
          import('./Dashboard/dashboard-routes').then(
            (d) => d.DASHBOARD_ROUTES,
          ),
      },
    ],
  },
];
