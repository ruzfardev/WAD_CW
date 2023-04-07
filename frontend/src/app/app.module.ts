import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RecipesComponent } from './recipes/recipes.component';
import { ShowRecipesComponent } from './recipes/show-recipes/show-recipes.component';
import { AddEditRecipesComponent } from './recipes/add-edit-recipes/add-edit-recipes.component';
import { UsersComponent } from './users/users.component';
import { SharedService } from './shared.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DetailedViewComponent } from './recipes/detailed-view/detailed-view.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserService } from './user.service';
import { NavigationComponent } from './navigation/navigation.component';
import {AuthGuardService} from "./authguard.service";
import { MyRecipesComponent } from './my-recipes/my-recipes.component';
import { ProfileComponent } from './profile/profile.component';
import { BookmarksComponent } from './recipes/bookmarks/bookmarks.component';
@NgModule({
  declarations: [
    AppComponent,
    RecipesComponent,
    ShowRecipesComponent,
    AddEditRecipesComponent,
    UsersComponent,
    DetailedViewComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    NavigationComponent,
    MyRecipesComponent,
    ProfileComponent,
    BookmarksComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ],
  providers: [SharedService, UserService, AuthGuardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
