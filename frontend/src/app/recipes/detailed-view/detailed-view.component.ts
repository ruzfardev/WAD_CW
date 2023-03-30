import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { SharedService } from 'src/app/shared.service';
import { UserService } from 'src/app/user.service';

@Component({
  selector: 'app-detailed-view',
  templateUrl: './detailed-view.component.html',
  styleUrls: ['./detailed-view.component.css']
})
export class DetailedViewComponent {
  
    RecipeId: any;
    Recipe: any = {};
    user: any;
    userSubscription: Subscription;
  constructor(private service: SharedService, private userService: UserService, private router: Router, private route: ActivatedRoute) {
    this.userSubscription = this.userService.getUserSubject().subscribe((user: any) => {
      this.user = user;
    });
   }

  ngOnInit(): void {
    this.RecipeId = this.route.snapshot.paramMap.get('id');
    this.service.getRecipeById(this.RecipeId).subscribe((data: any) => {
      this.Recipe = data;
    } );
  }

  back() {
    this.router.navigate(['/recipes']);
  }
}
