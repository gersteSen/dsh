import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { PagesConfig } from '../../../../../../_config/pages.config';

@Component({
  selector: 'dsh-sidebar',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
})
export class Sidebar {
  mainNavi: PagesConfig[] = [
    { label: 'Dashboard', icon: 'dashboard', route: '/Dashboard' },
    { label: 'Lehrer', icon: 'person', route: '/Teachers' },
    { label: 'Schüler', icon: 'group', route: '/Students' },
    { label: 'Räume', icon: 'door_open', route: '/Rooms' },
    { label: 'Stundenplan', icon: 'calendar_month', route: '/Schedule' },
    { label: 'Materialien', icon: 'library_books', route: '/Materials' },
  ];

  footerNavigation: PagesConfig[] = [
    { label: 'Settings', icon: 'settings', route: '/Settings' },
    { label: 'Logout', icon: 'logout', route: '/Logout' },
  ];
}
