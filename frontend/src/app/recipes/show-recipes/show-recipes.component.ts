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
  bookmarkSubs: Subscription;
  bookmarks: any[] = [];
  constructor(public service: SharedService, private userService: UserService) {
    this.userSubscription = this.userService.getUserSubject().subscribe((user: any) => {
      this.user = user;
    });
    this.bookmarkSubs = this.service.getUserBookmarks().subscribe((bookmarks: any) => {
      this.bookmarks = bookmarks;
    } );
    // this.userBookmarks = this.service.getUserBookmarks();
  }

  ngOnInit():void {
    this.isLoading = true;
    this.service.getUserBookmarks().subscribe((bookmarks: any) => {
      this.bookmarks = bookmarks;
      this.service.getRecipeList().subscribe((recipes: any) => {
        this.RecipesList = recipes;
        this.RecipesList.forEach((recipe: any) => {
          const isBookmarked = this.bookmarks.some((bookmark: any) => bookmark.recipeId === recipe.id);
          recipe.isBookmarked = isBookmarked;
        });
        this.isLoading = false;
      }, (error: any) => {
        console.error('Error getting recipes: ', error);
        alert('Error getting recipes');
        this.isLoading = false;
      });
    }, (error: any) => {
      console.error('Error getting bookmarks: ', error);
      alert('Error getting bookmarks');
      this.isLoading = false;
    });
  }
  ngOnDestroy(): void {
    this.bookmarkSubs.unsubscribe();
  }

  added(){
    alert("Recipe already bookmarked");
  }
  addBookmark(recipeId: number) {
    const recipeIndex = this.RecipesList.findIndex((recipe: any) => recipe.id === recipeId);
    if (recipeIndex !== -1) {
      this.service.addBookmark(recipeId).subscribe((data: any) => {
          alert("Recipe bookmarked successfully");
          this.RecipesList[recipeIndex].isBookmarked = true;
        },
        (error: any) => {
          alert('Error bookmarking recipe');
        });
    }
  }

}
