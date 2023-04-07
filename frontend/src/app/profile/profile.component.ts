import { Component } from '@angular/core';
import {SharedService} from "../shared.service";
import {UserService} from "../user.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  profileForm: FormGroup;
  userData: any;
  user: any;
  constructor(private service: SharedService, private userService: UserService) {
    this.profileForm = new FormGroup({ });
    this.user = this.userService.getUser();
  }

  ngOnInit(): void {
    this.profileForm = new FormGroup({
      firstName: new FormControl(null, Validators.required),
      lastName: new FormControl(null, Validators.required),
      email: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required),
    } );
    this.service.getUserById(this.user.userId).subscribe((data: any) => {
      this.userData = data;
      this.profileForm = new FormGroup({
        firstName: new FormControl(this.userData.firstName, Validators.required),
        lastName: new FormControl(this.userData.lastName, Validators.required),
        email: new FormControl(this.userData.email, Validators.required),
        password: new FormControl(this.userData.password, Validators.required),
      });
    } );
  }

  onSubmit(): void {
      try {
        this.service.updateUser(this.profileForm.value, this.user.userId).subscribe((data: any) => {
          alert("User updated successfully");
          this.userData = data;
          this.userService.setUser(data);
          localStorage.setItem('user', JSON.stringify(data));
        }, (error: any) => {
          alert("Error updating user");
        } );
      }   catch (error: any) {
        alert("Error updating user");
      }
  }
}
