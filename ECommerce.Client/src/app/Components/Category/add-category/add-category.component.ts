import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/Models/Category.model';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {

  addCategoriesRequest: Category = {
    id: 0,
    name: '',
    createdDate: new Date()
  }
  constructor(private categoriesService: CategoriesService, private router: Router, private toastr: ToastrService){}

  noOnInit():void
  {

  }
  addCategory(){
    this.categoriesService.addCategory(this.addCategoriesRequest)
    .subscribe({
      next: (categories) =>
      {
        console.log(categories);
        this.router.navigate(['category']);
        this.toastr.success('Success', 'Toast');
      },
      error: (response) =>
      {
        console.log(response);
        this.toastr.error(response, 'error');
      }
    }
    );
  }
}
