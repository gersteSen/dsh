import { inject, Service } from '@angular/core';
import { Router } from '@angular/router';

@Service()
export class NavigationService {
  #router = inject(Router);

  navigate2Dashboard(): void {
    this.#router.navigate(['Dashboard']);
  }
}
