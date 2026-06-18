import { EnvironmentInterface } from './environment.interface';

export const environment: EnvironmentInterface = {
  isProduction: false,
  useMock: {
    teacherMock: false,
    instrumentMock: true,
    studentMock: true,
  },
};
