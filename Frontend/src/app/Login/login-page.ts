import { Component } from '@angular/core';
import { BasicInput } from '@shared/_components/basic-input/basic-input';
import { IconButton } from '@shared/_components/icon-button/icon-button';

@Component({
  selector: 'dsh-login-page',
  imports: [BasicInput, IconButton],
  templateUrl: './login-page.html',
  styleUrl: './login-page.css',
})
export class LoginPage {}
