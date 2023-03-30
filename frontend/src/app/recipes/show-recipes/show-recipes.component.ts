import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/user.service';
import { SharedService } from '../../shared.service';
@Component({
  selector: 'app-show-recipes',
  templateUrl: './show-recipes.component.html',
  styleUrls: ['./show-recipes.component.css']
})
export class ShowRecipesComponent {
  RecipesList: any = [];
  isLoading: boolean = false;
  user: any;
  userSubscription: Subscription;
  constructor(public service: SharedService, private userService: UserService) { 
    this.userSubscription = this.userService.getUserSubject().subscribe((user: any) => {
      this.user = user;
    });
  }
  
  ngOnInit():void {
    this.refreshRecipesList();
  }

  refreshRecipesList() {
    this.isLoading = true;
    this.service.getRecipeList().subscribe(data => {
      console.log(data);
      this.RecipesList = data;
      this.isLoading = false;
    }
  );
}}
