import { Component, inject, input, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { ActivatedRoute } from '@angular/router';
import { CreateNewTeacherDialog } from '@app/Teacher/teachers/create-new-teacher-dialog/create-new-teacher-dialog';
import { SidebarWithRouterOutlet } from '@app/_shared/_components/layout/sidebar-with-router-outlet/sidebar-with-router-outlet';
import { PageContainer } from '@shared/_components/layout/page/page';
import { map } from 'rxjs';
import { TeacherStateStore } from './_store/teacher-state.store';

@Component({
  selector: 'dsh-teacher',
  imports: [PageContainer, CreateNewTeacherDialog, SidebarWithRouterOutlet],
  template: ` <dsh-sidebar-with-router-outlet>
    <dsh-page
      [titel]="title()"
      [showSubmenu]="showSubmenu()"
      (showSubmenuChange)="showCreateTeacherDialog.set($event)"
    >
      @if (showCreateTeacherDialog()) {
        <dsh-create-new-teacher-dialog (closeEvent)="toggleDialog()" />
      }
    </dsh-page>
  </dsh-sidebar-with-router-outlet>`,
  providers: [TeacherStateStore],
})
export class TeacherPage {
  #route = inject(ActivatedRoute);
  teacherFullName = input<string | undefined>('Lehrer');

  showCreateTeacherDialog = signal<boolean>(false);

  // Da 'PageContainer' die Child-Routen umschließt,
  // wandern wir via '.firstChild' tiefer, falls eine Child-Route aktiv ist.
  #activeRouteData$ = this.#route.firstChild
    ? this.#route.firstChild.data
    : this.#route.data;

  // Jetzt mappen wir ganz entspannt auf die gewünschten Properties
  title = toSignal(
    this.#activeRouteData$.pipe(
      map((data) => data['title'] ?? 'Gib mir einen Titel'),
    ),
    { initialValue: 'GrooveDesk' },
  );

  showSubmenu = toSignal(
    this.#activeRouteData$.pipe(map((data) => data['showSubmenu'] ?? false)),
    { initialValue: false },
  );

  toggleDialog(): void {
    this.showCreateTeacherDialog.update((value) => !value);
  }
}
