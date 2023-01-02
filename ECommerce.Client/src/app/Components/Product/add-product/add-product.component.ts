import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Product } from 'src/app/Models/Product.model';
import { ProductsService } from 'src/app/services/products.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CategoriesService } from 'src/app/services/categories.service';
import { Category } from 'src/app/Models/Category.model';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  public files: any[];
  categories: Category[] = [];
  isSubmitted: boolean = false;
  addProductRequest!: Product;

  // addProductRequest: Product = {
  //   id:0,
  //   arabicName: '',
  //   englishName: '',
  //   price: 0,
  //   description: '',
  //   hasAvailableStock: false,
  //   image : '',
  //   fK_CategoryId: 0,
  // }

  addProductForm: FormGroup = this.formBuilder.group({
    englishName: ["", [Validators.required]],
    arabicName: ["", [Validators.required]],
    price: [0, [Validators.required]],
    description: ["", []],
    hasAvailableStock: [true, Validators.required],
    fK_CategoryId: ["", [Validators.required]],
  });

  
  constructor(private productService: ProductsService,private categoriesService: CategoriesService, private router: Router, private toastr: ToastrService, private formBuilder: FormBuilder){this.files = [];}

  onFileChanged(event: any) {
    this.files = event.target.files;
  }

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

  addProduct(){
    this.isSubmitted = true;
    if (this.addProductForm.valid) {
      const formCopy = Object.assign({}, this.addProductForm.getRawValue());
      this.addProductRequest = formCopy;

      this.productService.addProduct(this.addProductRequest)
    .subscribe({
      next: (products) =>
      {
        this.router.navigate(['product']);
        this.toastr.success('Success', 'Toast');
      },
      error: (response) =>
      {
        this.toastr.error(response, 'error');
      }
    }
    );
    }
    
  }

}
