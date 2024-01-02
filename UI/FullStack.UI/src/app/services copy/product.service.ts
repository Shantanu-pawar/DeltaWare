import { Injectable } from '@angular/core';
import { environment } from 'environments/environment.development';
import { Observable } from 'rxjs';
import { Product } from '@app/Models/product.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
}) 
export class ProductsService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  // oberservable method to map the product type obj coming from api
  getAllProducts(): Observable <Product[]>{
    return this.http.get<Product[]>(this.baseApiUrl + '/api/products')
  }
}
