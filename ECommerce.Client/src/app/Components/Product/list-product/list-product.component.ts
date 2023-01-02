import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/Product.model';
import { ProductsService } from 'src/app/services/products.service';
import {MatPaginatorModule} from '@angular/material/paginator';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {

  products: Product[] = [];
  displayedColumns = ['englishname', 'arabicName', 'category']
  constructor(private productsService: ProductsService) {}

  ngOnInit(): void {
    this.productsService.getAllProducts()
    .subscribe({
      next: (products) =>
      {
        this.products = products;
        console.log(this.products);
      },
      error: (response) =>
      {
        console.log(response);
      }
    }
    );
  }
}
