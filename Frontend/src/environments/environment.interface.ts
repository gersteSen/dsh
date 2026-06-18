import { InjectionToken } from '@angular/core';

export const ENV = new InjectionToken<EnvironmentInterface>('ENV');

export type EnvironmentInterface = {
  isProduction: boolean;
  useMock?: {
    teacherMock: boolean;
    instrumentMock: boolean;
    studentMock: boolean;
  };
};
