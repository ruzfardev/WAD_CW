import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import {RecipesComponent} from './recipes/recipes.component';
import { AddEditRecipesComponent } from './recipes/add-edit-recipes/add-edit-recipes.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DetailedViewComponent } from './recipes/detailed-view/detailed-view.component';
import {AuthGuardService} from "./authguard.service";
import {MyRecipesComponent} from "./my-recipes/my-recipes.component";
import {ProfileComponent} from "./profile/profile.component";
import {BookmarksComponent} from "./recipes/bookmarks/bookmarks.component";

const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path:'register', component: RegisterComponent
  },
  {
    path: 'recipes', component: RecipesComponent, canActivate: [AuthGuardService]
  },
  {
    path: 'recipes/add', component: AddEditRecipesComponent, canActivate: [AuthGuardService]
  },
  {
    path: 'recipes/:id', component: DetailedViewComponent, canActivate: [AuthGuardService]
  },
  {
    path: 'recipes/edit/:id', component: AddEditRecipesComponent , canActivate: [AuthGuardService]
  },
  {
    path: 'my-recipes', component: MyRecipesComponent, canActivate: [AuthGuardService]
  },
  {
    path: 'profile', component: ProfileComponent, canActivate: [AuthGuardService]
  },
  {
    path: 'bookmarks', component: BookmarksComponent, canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
