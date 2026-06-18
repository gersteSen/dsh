import { Component, input, linkedSignal, output } from '@angular/core';
import { TeacherInstrumentDto } from '@generated/model/teacherInstrumentDto';
import { Icon } from '@shared/_components/icon/icon';

@Component({
  selector: 'dsh-instrument-card',
  imports: [Icon],
  templateUrl: './instrument-card.html',
  styleUrl: './instrument-card.css',
})
export class InstrumentCard {
  instrument = input.required<TeacherInstrumentDto>();

  protected localInstrument = linkedSignal(() => this.instrument());

  protected toggleInstrumentEvent = output<TeacherInstrumentDto>();

  protected onAktiv(): void {
    this.localInstrument.update(i => ({ ...i, active: true }));
    this.toggleInstrumentEvent.emit(this.localInstrument());
  }

  protected onInaktiv(): void {
    this.localInstrument.update(i => ({ ...i, active: false }));
    this.toggleInstrumentEvent.emit(this.localInstrument());
  }

  protected isActive(): boolean {
    return this.localInstrument().active!;
  }
}
