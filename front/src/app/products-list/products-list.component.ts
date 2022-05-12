
import { Component, OnInit } from '@angular/core';
import { Product } from '../products';
//const axios = require('axios');
import axios from 'axios';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
  products: [Product] | undefined;
  constructor() {
     this.getAllProdutcs();
   }

  ngOnInit(): void {

  }

  getAllProdutcs(){

    var config = {
      method: 'get',
      url: 'http://localhost:5236/product/getall',
      headers: { }
    };

    axios(config)
    .then(function (response : any) {
      console.log(JSON.stringify(response.data));
    })
    .catch(function (error: any) {
      console.log(error);
    });

  }


  // itens = document.querySelectorAll(".productComponent");
  // itens.forEach(elemen(item) {
  //   item.
  // });
}
