import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from '../user.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {
  user: any;
  userSubscription: Subscription;
  constructor(private userService: UserService) {
    this.userSubscription = this.userService.getUserSubject().subscribe((user: any) => {
      this.user = user;
    });
  }

  ngOnInit(): void {
    const user = localStorage.getItem('user');
    if (user) {
      console.log(JSON.parse(user));
      this.userService.setUser(JSON.parse(user));
      this.user = JSON.parse(user);
    }
  }

  ngOnDestroy(): void {
    this.userSubscription.unsubscribe();
  }


  logoutUser() {
    this.userService.logout();
  }
}
