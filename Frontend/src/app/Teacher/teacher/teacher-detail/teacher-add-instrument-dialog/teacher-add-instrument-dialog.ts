import { Component, inject, input, output } from '@angular/core';
import { Dialog, DialogData } from '@app/_shared/_components/dialog/dialog';
import { TeacherInstrumentDto, UpdateTeacherDto } from '@generated/index';
import { InstrumentCard } from '@shared/_components/instrument-card/instrument-card';
import { TeacherStateStore } from '@app/Teacher/_store/teacher-state.store';

@Component({
  selector: 'dsh-teacher-add-instrument-dialog',
  imports: [Dialog, InstrumentCard],
  templateUrl: './teacher-add-instrument-dialog.html',
  styleUrl: './teacher-add-instrument-dialog.css',
})
export class TeacherAddInstrumentDialog {
  activeInstruments = input<TeacherInstrumentDto[]>([]);
  store = inject(TeacherStateStore);
  dialogData: DialogData = {
    title: 'Aktive Instrumente pflegen',
  };
  closeEvent = output<void>();

  onClick(): void {
    this.closeEvent.emit();
  }

  protected toggleInstrument($event: TeacherInstrumentDto) {
    this.store.toggleInstrument($event);
    this.store.updateTeacherRXJS({
      ...this.store.selectedTeacher(),
      instrumentIds:
        this.store
          .selectedTeacher()
          ?.instruments?.filter((x) => x.active)
          .map((x) => x.id!) ?? [],
    } as UpdateTeacherDto);
  }
}
