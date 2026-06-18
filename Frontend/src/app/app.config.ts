import {
  ApplicationConfig,
  isDevMode,
  provideBrowserGlobalErrorListeners,
} from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';

import { environment } from 'src/environments/environment';
import { ENV } from 'src/environments/environment.interface';
import { provideApi } from 'src/_generated/provide-api';
import { InstrumentServiceProvider } from './_services/instrument/instrument.provider';
import { TeacherServiceProvider } from './_services/teacher/teacher.provider';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    { provide: ENV, useValue: environment },
    provideApi(''),
    ...TeacherServiceProvider,
    ...InstrumentServiceProvider,
    provideRouter(routes, withComponentInputBinding()),
    provideStore(),
    provideStoreDevtools({
      maxAge: 25, // Retains last 25 states
      logOnly: !isDevMode(), // Restrict extension to log-only mode
      autoPause: true, // Pauses recording actions and state changes when the extension window is not open
      trace: false, //  If set to true, will include stack trace for every dispatched action, so you can see it in trace tab jumping directly to that part of code
      traceLimit: 75, // maximum stack trace frames to be stored (in case trace option was provided as true)
      connectInZone: true, // If set to true, the connection is established within the Angular zone
    }),
  ],
};
