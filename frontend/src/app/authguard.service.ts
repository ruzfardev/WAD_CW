import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { UserService } from './user.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate{

  constructor(private userService: UserService, private router: Router) {}

  canActivate(): boolean {
    if (this.userService.getUser()) {
      return true;
    } else {
      this.router.navigate(['/login']);
      return false;
    }
  }
}
