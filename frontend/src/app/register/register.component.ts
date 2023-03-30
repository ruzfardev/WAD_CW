import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registerForm: FormGroup;
  constructor(public service: SharedService, private userService: UserService, private router: Router, private route: ActivatedRoute) {
    this.registerForm = new FormGroup({
      firstName: new FormControl(null, Validators.required),
      lastName: new FormControl(null, Validators.required),
      email: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required),
    });
  }

  ngOnInit(): void {

  }

  onSubmit(): void {
    try {
      this.service.registerUser(this.registerForm.value).subscribe((data: any) => {
        localStorage.setItem('user', JSON.stringify(data));
        this.userService.setUser(data);
        this.router.navigate(['/recipes']);
      }
      );
    } catch (error) {
      alert('Invalid Credentials');
      console.log(error);
    }
  }

}
