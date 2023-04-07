import { Component } from '@angular/core';
import {SharedService} from "../shared.service";
import {UserService} from "../user.service";

@Component({
  selector: 'app-my-recipes',
  templateUrl: './my-recipes.component.html',
  styleUrls: ['./my-recipes.component.css']
})
export class MyRecipesComponent {
  myRecipes: any;
  user: any;
  isLoading: boolean = false;
  constructor(private service: SharedService, private userService: UserService) {
    this.user = this.userService.getUser();

    // this.myRecipes = this.service.getRecipeByUserId(this.user?.userId);
  }

  ngOnInit(): void {
    this.refreshRecipesList();
  }

  refreshRecipesList() {
    this.isLoading = true;
    this.myRecipes = this.service.getRecipeByUserId(this.user?.userId).subscribe((data: any) => {
      this.myRecipes = data;
      console.log(data);
      this.isLoading = false;
    },
    (error) => {
      alert('Error loading recipes. Please try again later.');
      this.isLoading = false;
    });
  }
}
