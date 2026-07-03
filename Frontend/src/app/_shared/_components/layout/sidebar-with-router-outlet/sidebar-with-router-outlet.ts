import { Component } from '@angular/core';
import { Sidebar } from './sidebar/sidebar';

@Component({
  selector: 'dsh-sidebar-with-router-outlet',
  imports: [Sidebar],
  templateUrl: './sidebar-with-router-outlet.html',
  styleUrl: './sidebar-with-router-outlet.css',
})
export class SidebarWithRouterOutlet {}
