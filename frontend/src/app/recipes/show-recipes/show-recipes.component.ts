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
  isBookmarksLoading: boolean = false;
  user: any;
  userSubscription: Subscription;
  userBookmarks: any = [];
  constructor(public service: SharedService, private userService: UserService) {
    this.userSubscription = this.userService.getUserSubject().subscribe((user: any) => {
      this.user = user;
    });
    // this.userBookmarks = this.service.getUserBookmarks();
  }

  ngOnInit():void {
    this.refreshRecipesList();
    this.isBookmarksLoading = true;
    // this.userBookmarks = this.service.getUserBookmarks().subscribe((bookmarks: any) => {
    //   this.userBookmarks = bookmarks;
    //   this.isBookmarksLoading = false;
    // } );
  }

  refreshRecipesList() {
    this.isLoading = true;
    this.service.getRecipeList().subscribe(data => {
      this.RecipesList = data;
      this.isLoading = false;
    }
  );
  }
  isBookmarked(recipeId: number): boolean {
    // Check if the recipe is bookmarked by the current user
    // if (this.userBookmarks && !this.isBookmarksLoading) {
    //   console.log(this.userBookmarks);
    //   console.log(this.RecipesList);
    //   this.userBookmarks.forEach((bookmark: any) => {
    //     if (bookmark.recipeId === recipeId) {
    //       return true;
    //     }else{
    //       return false;
    //     }
    //   });
    // }
    return false;

  }

  addBookmark(recipeId: number) {
    this.service.addBookmark(recipeId).subscribe((data: any) => {
       alert("Recipe bookmarked successfully");
    },
      (error: any) => {
        alert(error.erro);
      });
  }
}
