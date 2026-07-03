import { Component, inject } from '@angular/core';
import { BasicInput } from '@shared/_components/basic-input/basic-input';
import { IconButton } from '@shared/_components/icon-button/icon-button';
import { NavigationService } from '@services/naviation/navigation.service';

@Component({
  selector: 'dsh-login-page',
  imports: [BasicInput, IconButton],
  templateUrl: './login-page.html',
  styleUrl: './login-page.css',
})
export class LoginPage {
  #navigationService = inject(NavigationService);
  protected navigateToDashboard(): void {
    this.#navigationService.navigate2Dashboard();
  }
}
