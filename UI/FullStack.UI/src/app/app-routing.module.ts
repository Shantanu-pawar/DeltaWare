import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import path from 'path/posix';
import { ProductListComponent } from './components/product/product-list/product-list.component';

const routes: Routes = [
  {
    path: '',
    component : ProductListComponent
  },
  {
    path: 'product', // app routing cannot have slashe
    component : ProductListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
