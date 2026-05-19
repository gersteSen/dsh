import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'dsh-root',
  template: ` <router-outlet></router-outlet> `,
  imports: [RouterOutlet],
})
export class App {}
