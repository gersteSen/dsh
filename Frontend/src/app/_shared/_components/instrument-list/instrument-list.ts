import { Component, input, output } from '@angular/core';
import { InstrumentDto } from '@generated/model/instrumentDto';
import { Chip } from '@shared/_components/chip/chip';
import { Icon } from '@shared/_components/icon/icon';

@Component({
  selector: 'dsh-instrument-list',
  imports: [Chip, Icon],
  templateUrl: './instrument-list.html',
  styleUrl: './instrument-list.css',
})
export class InstrumentList {
  instruments = input.required<InstrumentDto[]>();

  aktivClicked = output<InstrumentDto>();
  inaktivClicked = output<InstrumentDto>();

  protected onAktiv(instrument: InstrumentDto): void {
    this.aktivClicked.emit(instrument);
  }

  protected onInaktiv(instrument: InstrumentDto): void {
    this.inaktivClicked.emit(instrument);
  }
}
