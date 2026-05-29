import { Routes } from '@angular/router';

export const Settings_ROUTES: Routes = [
  {
    path: '',
    loadComponent: () => import('./settings/settings').then((s) => s.Settings),
  },
];
