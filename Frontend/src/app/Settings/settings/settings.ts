import { Component } from '@angular/core';
import { BasicInput } from '../../_shared/_components/basic-input/basic-input';
import { ThemeSwitch } from '../../_shared/_components/theme-switch/theme-switch';

@Component({
  selector: 'dsh-settings',
  imports: [BasicInput, ThemeSwitch],
  templateUrl: './settings.html',
  styleUrl: './settings.css',
})
export class Settings {}
