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
      }
    , {headers});
  }

  updateRecipe(val: any, id: number) {
    return this.https.put(this.APIUrl + `/Recipes/${id}`, 
      {
        ...val,
        userId: this.user.userId,
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

}
