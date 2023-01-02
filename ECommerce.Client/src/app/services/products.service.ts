import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../Models/Product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  baseurl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAllProducts() : Observable<Product[]>
  {
    return this.http.get<Product[]>(this.baseurl + '/api/Product/GetAllProducts');
  }
  getProduct(id: string) : Observable<Product>
  {
    return this.http.get<Product>(this.baseurl + '/api/Product/' + id);
  }
  addProduct(addProductRequest: Product) : Observable<Product>{
    return this.http.post<Product>(this.baseurl + '/api/Product/CreateProduct', addProductRequest);
  }
}
