import { isDevMode, Provider } from '@angular/core';
import { InstrumentService } from './instrument.service';
import {
  INSTRUMENT_SERVICE,
  InstrumentServiceInterface,
} from './instrument.service.interface';
import { InstrumentMockService } from './instrument.service.mock';

export const InstrumentServiceProvider: Provider[] = [
  InstrumentService,
  {
    provide: INSTRUMENT_SERVICE,
    useFactory: (service: InstrumentService): InstrumentServiceInterface => {
      return isDevMode() ? new InstrumentMockService() : service;
    },
    deps: [InstrumentService],
  },
];
