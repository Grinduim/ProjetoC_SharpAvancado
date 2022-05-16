
import { Component, OnInit } from '@angular/core';
import { Product } from '../products';
import { ActivatedRoute } from '@angular/router'
import axios from 'axios';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: Product | undefined;


  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const productIdFromRoute = Number(routeParams.get('productID'));
    this.getProduct(productIdFromRoute);

  }


  getProduct(id:number){
    var instance = this;
    var config = {
      method: 'get',
      url: 'http://localhost:5236/product/getproduct/' + id,
      headers: { }
    };
    var instance = this;
    axios(config)
    .then(function (response:any) {
      instance.product = response.data.product;
      if (instance.product != undefined)
        instance.product.unit_price = response.data.unit_price;
    })
    .catch(function (error:any) {
      console.log(error);
    });
  }


}
