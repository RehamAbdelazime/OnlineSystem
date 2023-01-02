import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/Models/Category.model';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})

export class EditCategoryComponent implements OnInit{

  isSubmitted: boolean = false;

  categoryDetails: Category = {
    id: 0,
    name: '',
    createdDate: new Date()
  }

  
  editCategoryForm: FormGroup = this.formBuilder.group({
    englishName: ["", [Validators.required]],
    arabicName: ["", [Validators.required]]
  });

  constructor(private route: ActivatedRoute, private categoriesService: CategoriesService, private formBuilder: FormBuilder ){}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) =>
      {
        const id = params.get('id');
        if(id)
        {
          this.categoriesService.getCategory(id)
          .subscribe({
            next: (response) =>{
              this.categoryDetails = response
            }
          });
        }
      }
    });
  }
  editCategory(){
    
  }
  
}
