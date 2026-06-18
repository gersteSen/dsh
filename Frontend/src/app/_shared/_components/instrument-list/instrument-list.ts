import { Component, computed, inject, output } from '@angular/core';
import { TeacherInstrumentDto } from '@generated/model/models';
import { InstrumentCard } from '@shared/_components/instrument-card/instrument-card';
import { TeacherStateStore } from '@app/Teacher/_store/teacher-state.store';

@Component({
  selector: 'dsh-instrument-list',
  imports: [InstrumentCard],
  templateUrl: './instrument-list.html',
  styleUrl: './instrument-list.css',
})
export class InstrumentList {
  store = inject(TeacherStateStore);
  instrumentList = computed(() => this.store.selectedTeacher()?.instruments ?? []);

  protected toggleInstrumentEvent = output<TeacherInstrumentDto>();

  protected toggleInstrument($event: TeacherInstrumentDto) {
    this.store.toggleInstrument($event);
    console.log('current State of Teacher: ', this.store.selectedTeacher());
  }
}
