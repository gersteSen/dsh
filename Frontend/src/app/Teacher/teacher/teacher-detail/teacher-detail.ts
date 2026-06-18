import { CommonModule } from '@angular/common';
import { Component, computed, input, signal } from '@angular/core';
import { Chip } from '@app/_shared/_components/chip/chip';
import { IconButton } from '@app/_shared/_components/icon-button/icon-button';
import { Icon } from '@app/_shared/_components/icon/icon';
import { TeacherDto, TeacherInstrumentDto } from '@generated/model/models';
import { TeacherAddInstrumentDialog } from './teacher-add-instrument-dialog/teacher-add-instrument-dialog';

@Component({
  selector: 'dsh-teacher-detail',
  imports: [CommonModule, IconButton, Chip, Icon, TeacherAddInstrumentDialog],
  templateUrl: './teacher-detail.html',
  styleUrl: './teacher-detail.css',
})
export class TeacherDetail {
  teacher = input<TeacherDto | null>(null);

  activeInstruments = computed<TeacherInstrumentDto[]>(
    () => this.teacher()?.instruments?.filter((x) => x.active) ?? [],
  );
  showDialog = signal<boolean>(false);

  openDialog(): void {
    this.showDialog.set(true);
  }
}
