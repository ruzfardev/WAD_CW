import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, Subscription } from 'rxjs';
import { UserService } from './user.service';
@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:5001/api";
  userSubscription : Subscription;
  user: any;
  constructor(private https: HttpClient, private userService: UserService,) {
    this.userSubscription = this.userService.getUserSubject().subscribe((user: any) => {
      this.user = user;
    });
  }
  loginUser(val: any) {
    try {
      const response = this.https.post(this.APIUrl + '/Users/Login', val);
      return response;

    } catch (error: any) {
      let errMsg: string;
      if(error.status === 400) {
        errMsg = 'Invalid email or password';
      } else {
        errMsg = 'Something went wrong';
      }
      throw new Error(errMsg);
    }
  }
  registerUser(val: any) {
    return this.https.post(this.APIUrl + '/Users', val);
  }
  getUserById(id: number): Observable<any> {
    return this.https.get<any>(this.APIUrl + '/Users/' + id, {
      headers: {
        'Content-Type': 'application/json',
        "Access-Control-Allow-Origin": "*"
      }
    } );
  }
  updateUser(val: any, id: number) {
    return this.https.put(this.APIUrl + '/Users', {
      ...val,
      userId: id
    });
  }
  getRecipeList(): Observable<any[]> {
    return this.https.get<any>(this.APIUrl + '/Recipes', {
      headers: {
        'Content-Type': 'application/json',
        "Access-Control-Allow-Origin": "*"
      }
    });
  }
  addRecipe(val: any) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    return this.https.post(this.APIUrl + '/Recipes',
      {
        ...val,
        userId: this.user.userId,
        categoryId: Number(val.categoryId)
      }
    , {headers});
  }
  updateRecipe(val: any, id: number) {
    return this.https.put(this.APIUrl + `/Recipes`,
      {
        ...val,
        id: id,
        userId: this.user.userId,
        categoryId: Number(val.categoryId)
      }
    );
  }
  getCategories(): Observable<any[]> {
    return this.https.get<any>(this.APIUrl + '/Category', {
      headers: {
        'Content-Type': 'application/json',
        "Access-Control-Allow-Origin": "*"
      }});
  }
  getRecipeById(val: number): Observable<any> {
    return this.https.get<any>(this.APIUrl + '/Recipes/' + val, {
      headers: {
        'Content-Type': 'application/json',
        "Access-Control-Allow-Origin": "*"
      }
    });
  }
  getRecipeByUserId(userId: number): Observable<any> {
    try {
      const response = this.https.get(this.APIUrl + '/Recipes/byUser/' + userId, {
        headers: {
          'Content-Type': 'application/json',
          "Access-Control-Allow-Origin": "*"
        }
      });
      return response;
    }catch (error: any) {
      throw new Error('Something went wrong');
    }
  }
  addBookmark(recipeId: number) {
    try {
      const response = this.https.post(this.APIUrl + '/Bookmark', {
        recipeId,
        userId: this.user.userId,
      });
      return response;
    } catch (error: any) {
      throw new Error('Something went wrong');
    }
  }
  deleteRecipe(id: number) {
    try {
      const response = this.https.delete(this.APIUrl + '/Recipes/' + id);
      return response;
    }catch (error: any) {
      throw new Error('Something went wrong');
    }
  }
  getUserBookmarks(): Observable<any[]> {
    return this.https.get<any>(this.APIUrl + '/Bookmark/' + this.user.userId, {
      headers: {
        'Content-Type': 'application/json',
        "Access-Control-Allow-Origin": "*"
      }
    });
  }
}
