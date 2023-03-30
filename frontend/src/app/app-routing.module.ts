import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import {RecipesComponent} from './recipes/recipes.component';
import { AddEditRecipesComponent } from './recipes/add-edit-recipes/add-edit-recipes.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { DetailedViewComponent } from './recipes/detailed-view/detailed-view.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path:'register', component: RegisterComponent
  }
  ,
  {
    path: 'recipes', component: RecipesComponent
  },
  {
    path: 'recipes/add', component: AddEditRecipesComponent
  },
  {
    path: 'recipes/:id', component: DetailedViewComponent
  },
  {
    path: 'recipes/edit/:id', component: AddEditRecipesComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
