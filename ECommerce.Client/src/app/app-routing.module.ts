import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCategoryComponent } from './Components/Category/add-category/add-category.component';
import { CategoryListComponent } from './Components/Category/category-list/category-list.component';
import { EditCategoryComponent } from './Components/Category/edit-category/edit-category.component';
import { AddProductComponent } from './Components/Product/add-product/add-product.component';
import { EditProductComponent } from './Components/Product/edit-product/edit-product.component';
import { ListProductComponent } from './Components/Product/list-product/list-product.component';

const routes : Routes = [
  {
    path: '',
    component: CategoryListComponent
  },
  {
    path: 'category',
    component: CategoryListComponent
  },
  {
    path: 'category/add',
    component: AddCategoryComponent
  },
  {
    path: 'category/edit/:id',
    component: EditCategoryComponent
  },
  {
    path: 'product',
    component: ListProductComponent
  },
  {
    path: 'product/add',
    component: AddProductComponent
  },
  {
    path: 'product/edit/:id',
    component: EditProductComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
