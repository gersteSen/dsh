import { Component, input, linkedSignal } from '@angular/core';
import { Page } from '@shared/_components/layout/page/page';

@Component({
  selector: 'dsh-teacher',
  imports: [Page],
  template: `<dsh-page [titel]="internalFullName()" />`,
})
export class TeacherPage {
  teacherFullName = input<string | undefined>('Lehrer');
  internalFullName = linkedSignal(() => this.teacherFullName() ?? 'Lehrer');
}
