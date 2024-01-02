import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Product } from '../Models/product.model';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
}) 
export class ProductsService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor( private http: HttpClient) { }

  // oberservable method to map the product type obj coming from api
  getAllProducts(): Observable <Product[]>{
    return this.http.get<Product[]>(this.baseApiUrl + 'api/product')
  }
}
