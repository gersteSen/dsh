import {
  ApplicationConfig,
  provideBrowserGlobalErrorListeners,
} from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';

import { TeacherServiceProvider } from './_services/teacher/teacher.provider';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    ...TeacherServiceProvider,
    provideRouter(routes, withComponentInputBinding()),
  ],
};
