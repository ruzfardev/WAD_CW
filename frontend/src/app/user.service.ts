import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private user : any;
  private userSubject = new BehaviorSubject<any>(null);

  constructor() { }

  setUser(user: any) {
    this.user = user;
    this.userSubject.next(user);
  }

  getUser() {
    return this.user;
  }
  getUserSubject(): BehaviorSubject<any> {
    return this.userSubject;
  }

  logout() {
    this.user = null;
    this.userSubject.next(null);
    localStorage.removeItem('user');
  }
}
