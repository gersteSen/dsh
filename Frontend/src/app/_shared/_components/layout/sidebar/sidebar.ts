import {Component} from '@angular/core';
import {RouterLink, RouterLinkActive} from '@angular/router';
import {PagesConfig} from '../../../../../_config/pages.config';


@Component({
  selector: 'dsh-sidebar',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
})
export class Sidebar {
  mainNavi: PagesConfig[] = [
    {label: 'Lehrer', icon: 'person', route: '/teachers'},
    {label: 'Räume', icon: 'door_open', route: '/rooms'},
    {label: 'Schüler', icon: 'group', route: '/students'},
    {label: 'Stundenplan', icon: 'calendar_month', route: '/schedule'},
    {label: 'Materialien', icon: 'library_books', route: '/materials'},
  ];

  footerNavigation: PagesConfig[] = [
    {label: 'Settings', icon: 'settings', route: '/settings'},
    {label: 'Logout', icon: 'logout', route: '/logout'},
  ];
}
