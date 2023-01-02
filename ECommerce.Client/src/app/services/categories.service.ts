import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Category } from '../Models/Category.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  baseurl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getAllCategories() : Observable<Category[]>
  {
    return this.http.get<Category[]>(this.baseurl + '/api/Category/GetAllCategories');
  }
  getCategory(id: string) : Observable<Category>
  {
    return this.http.get<Category>(this.baseurl + '/api/Category/' + id);
  }
  addCategory(addCategoriesRequest: Category) : Observable<Category>{
    return this.http.post<Category>(this.baseurl + '/api/Category/CreateCategory', addCategoriesRequest);
  }
}
