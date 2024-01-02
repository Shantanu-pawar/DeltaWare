import { Component, OnInit } from '@angular/core';
import { Product } from '../../../Models/product.model';
import { ProductsService } from '../../../services/product.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']

  // styleUrl: './product-list.component.css'
})

export class ProductListComponent implements OnInit{
  // handle'd the corner case in component.html -> if no product is found
  products : Product[] = [];
  constructor(public productsService : ProductsService){}

  ngOnInit(): void {
    this.productsService.getAllProducts()
    .subscribe({
      next: (products) => {
        this.products = products;
      },
      error: (err) => {
        console.log(err);
      }

    })
  }

}



// // internal data passing without db

  // ngOnInit(): void {
  // }

  // products: Product[] = [
  //   {
  //     productId: '2323',
  //     name: 'rating',
  //     description: 'Rating'
  //   }
  // ];
