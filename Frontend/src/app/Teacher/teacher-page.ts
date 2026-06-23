import { Component, inject, input, linkedSignal, signal } from '@angular/core';
import { Page } from '@shared/_components/layout/page/page';
import { TeacherStateStore } from './_store/teacher-state.store';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { filter, map, startWith } from 'rxjs';
import { IconButton } from '@shared/_components/icon-button/icon-button';
import { CreateNewTeacherDialog } from '@app/Teacher/teachers/create-new-teacher-dialog/create-new-teacher-dialog';

@Component({
  selector: 'dsh-teacher',
  imports: [Page, IconButton, CreateNewTeacherDialog],
  template: `<dsh-page [titel]="internalFullName()">
    @if (showTeachersSubmenu()) {
      <dsh-icon-button icon="add" (clickEvent)="toggleDialog()" />
    }
    @if (showCreateTeacherDialog()) {
      <dsh-create-new-teacher-dialog (closeEvent)="toggleDialog()" />
    }
  </dsh-page>`,
  providers: [TeacherStateStore],
})
export class TeacherPage {
  teacherFullName = input<string | undefined>('Lehrer');
  internalFullName = linkedSignal(() => this.teacherFullName() ?? 'Lehrer');

  showCreateTeacherDialog = signal<boolean>(false);

  private route = inject(ActivatedRoute);

  showTeachersSubmenu = toSignal(
    inject(Router).events.pipe(
      filter((e) => e instanceof NavigationEnd),
      startWith(null),
      map(
        () =>
          this.route.firstChild?.snapshot.data['showTeachersSubmenu'] ?? false,
      ),
    ),
    { initialValue: false },
  );

  toggleDialog(): void {
    this.showCreateTeacherDialog.update((value) => !value);
  }
}
