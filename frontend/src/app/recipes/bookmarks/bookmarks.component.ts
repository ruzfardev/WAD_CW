import { Component } from '@angular/core';
import {SharedService} from "../../shared.service";

@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.css']
})
export class BookmarksComponent {
  bookmarks: any[] = [];
  bookmarkedRecipes: any[] = [];
  isLoading = false;
  constructor(private service: SharedService) {}

  ngOnInit(): void {
    this.isLoading = true;
    this.service.getUserBookmarks().subscribe(
      (bookmarks: any) => {
        console.log(bookmarks);
        this.bookmarks = bookmarks;
        this.bookmarks.forEach((bookmark: any) => {
          this.service.getRecipeById(bookmark.recipeId).subscribe(
            (recipe: any) => {
              this.bookmarkedRecipes.push(recipe);
            },
            (error: any) => {
              console.error('Error getting recipe: ', error);
            }
          );
        });
        this.isLoading = false;
      },
      (error: any) => {
        console.error('Error getting bookmarks: ', error);
        alert('Error getting bookmarks');
        this.isLoading = false;
      }
    );
  }

}
