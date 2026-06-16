import { Pipe, PipeTransform } from '@angular/core';
import { Sex } from '@generated/model/models';

@Pipe({
  name: 'sex',
})
export class SexPipe implements PipeTransform {
  transform(value: Sex | undefined, ...args: unknown[]): unknown {
    switch (value) {
      case Sex.NUMBER_0:
        return 'Herr';
      case Sex.NUMBER_1:
        return 'Frau';
      default:
        return 'Unbekannt';
    }
  }
}
