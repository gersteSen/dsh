import { Component } from '@angular/core';
import {Sidebar} from './sidebar/sidebar';
import {RouterOutlet} from '@angular/router';

@Component({
  selector: 'dsh-sidebar-with-router-outlet',
  imports: [
    Sidebar,
    RouterOutlet
  ],
  templateUrl: './sidebar-with-router-outlet.html',
  styleUrl: './sidebar-with-router-outlet.css',
})
export class SidebarWithRouterOutlet {}
