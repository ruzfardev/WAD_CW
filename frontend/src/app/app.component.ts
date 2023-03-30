import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from './user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontend';
   
  constructor(private router: Router, private userService: UserService) {}
  ngOnInit(): void {
    const user = localStorage.getItem('user');
    if (user) {
      this.userService.setUser(JSON.parse(user));
    }
  }
}
