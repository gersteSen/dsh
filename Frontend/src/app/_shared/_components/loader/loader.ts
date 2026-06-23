import { Component, input } from '@angular/core';

@Component({
  selector: 'dsh-loader',
  imports: [],
  templateUrl: './loader.html',
  styleUrl: './loader.css',
})
export class Loader {
  text = input<string>('Loading ....');
}
