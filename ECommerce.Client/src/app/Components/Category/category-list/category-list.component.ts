import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/Models/Category.model';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  categories: Category[] = [];
  constructor(private categoriesService: CategoriesService) {}

  ngOnInit(): void {
    this.categoriesService.getAllCategories()
    .subscribe({
      next: (categories) =>
      {
        this.categories = categories;
        console.log(this.categories);
      },
      error: (response) =>
      {
        console.log(response);
      }
    }
    );
  }
}
