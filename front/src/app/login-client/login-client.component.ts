import { Component, OnInit } from '@angular/core';
import axios from "axios";

@Component({
  selector: 'app-login-client',
  templateUrl: './login-client.component.html',
  styleUrls: ['./login-client.component.css']
})
export class LoginClientComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


  login() {
    let user = document.getElementById("username") as HTMLInputElement;
    let passwd = document.getElementById("password") as HTMLInputElement;

    var data = JSON.stringify({
      "login": user.value,
      "passwd": passwd.value
    });

    console.log(user.value, passwd.value)

    var config = {

      method: 'post',
      url: 'http://localhost:5236/client/login',
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
     
    };
    
    axios(config)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
      })
  }
}
