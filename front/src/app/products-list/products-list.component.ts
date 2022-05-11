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

  products : [Product] | undefined;

  constructor() {
    this.getAllProdutcs();
   }

  ngOnInit(): void {

  }

  getAllProdutcs(){


    axios.get('http://localhost:5236/product/getall', {
      headers :{ "Access-Control-Allow-Origin" : "*",
      "Access-Control-Allow-Headers" : "Origin, X-Requested-With, Content-Type, Accept"}
    }).then(function (response: any) {
      console.log(response.data)
    })
    .catch(function (error: any) {
      console.log(error);
    });
  }

}
