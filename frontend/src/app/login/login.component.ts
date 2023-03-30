import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from '../shared.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;
  isSubmitting = false;
  constructor(public service: SharedService, private userService: UserService, private router: Router, private route: ActivatedRoute) {
    this.loginForm = new FormGroup({
      email: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required),
    });
   }
  
    ngOnInit(): void {

    }

    onSubmit(): void {
      try {
        this.isSubmitting = true;
        this.service.loginUser(this.loginForm.value).subscribe((data: any) => {
          this.userService.setUser(data);
          localStorage.setItem('user', JSON.stringify(data));
          this.isSubmitting = false;
          this.router.navigate(['/']);
        }
        );
      } catch (error) {
        alert('Invalid Credentials');
        console.log(error);
      }
    }



}
