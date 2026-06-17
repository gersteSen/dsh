import { Component, input, linkedSignal } from '@angular/core';
import { Page } from '@shared/_components/layout/page/page';
import { TeacherStateStore } from './_store/teacher-state.store';

@Component({
  selector: 'dsh-teacher',
  imports: [Page],
  template: `<dsh-page [titel]="internalFullName()" />`,
  providers: [TeacherStateStore],
})
export class TeacherPage {
  teacherFullName = input<string | undefined>('Lehrer');
  internalFullName = linkedSignal(() => this.teacherFullName() ?? 'Lehrer');
}
