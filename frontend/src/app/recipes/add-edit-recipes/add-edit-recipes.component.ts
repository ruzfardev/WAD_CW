import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-recipes',
  templateUrl: './add-edit-recipes.component.html',
  styleUrls: ['./add-edit-recipes.component.css']
})
export class AddEditRecipesComponent implements OnInit {
  pageTitle: string = 'Add Recipe';
  buttonText: string = 'Add Recipe';

  recipeForm: FormGroup;
  categories: { categoryId: number, categoryName: string }[] = [];
  constructor(public service: SharedService, private router: Router, private route: ActivatedRoute){
    this.recipeForm = new FormGroup({
      recipeName: new FormControl(null, Validators.required),
    });
  }
  ngOnInit(): void {
    this.recipeForm = new FormGroup({
      recipeName: new FormControl(null, Validators.required,),
      description: new FormControl(null),
      cookingTime: new FormControl(null),
      ingredients: new FormControl(null),
      servingSize: new FormControl(null),
      categoryId: new FormControl(null),
    });
      this.service.getCategories().subscribe((data: { categoryId: number, categoryName: string }[]) => {
        this.categories = data;
    });

    const recipeId = this.route.snapshot.paramMap.get('id');
    if (recipeId) {
      this.pageTitle = 'Edit Recipe';
      this.buttonText = 'Update Recipe';
      this.service.getRecipeById(parseInt(recipeId)).subscribe((data: {
        recipeName: string,
        description: string,
        cookingTime: number,
        servingSize: number,
        ingredients: string,
        categoryId: number,
       }) => {
        this.recipeForm?.setValue({
          recipeName: data.recipeName,
          description: data.description,
          cookingTime: data.cookingTime,
          ingredients: data.ingredients,
          servingSize: data.servingSize,
          categoryId: data.categoryId,
        });
      });
  }
}
onSubmit(): void {
  try {
    const recipeId = this.route.snapshot.paramMap.get('id');
    if(recipeId){
      this.service.updateRecipe(this.recipeForm.value, parseInt(recipeId)).subscribe((data: any) => {
        alert('Recipe updated successfully');
        this.router.navigate(['/recipes']);
      }, (error: any) => {
        alert(error.error);
      });
    }else{
      this.service.addRecipe(this.recipeForm.value).subscribe((data: any) => {
        alert('Recipe added successfully');
        this.router.navigate(['/recipes']);
      });
    }
  } catch (error: any) {
    alert(error);
  }
}

cancel(): void {
  this.router.navigate(['/recipes']);
}

}

