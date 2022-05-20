import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators,NgModel } from '@angular/forms';
//import { Client } from '../client';
import { Client } from "../client";
@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css']
})
export class ClientRegisterComponent implements OnInit {
  fomulario: FormGroup| undefined;
  client = {
    name: "",
    phone :"",
    email:"",
    password:"",
    login:"",
    birth:"",
    document:""

  }

  ngOnInit(): void {
    this.AddFuncitions();
  }

  AddFuncitions() {
    let button = document.getElementById('save');
    button?.addEventListener('click', this.VerifyForm)
    // let cancel = document.getElementById('reset');
    // cancel?.addEventListener('click',this.VerifyForm);
  }

  VerifyForm() {
    let allInputs: Array<any> = [];
    let name = document.getElementById('name') as HTMLInputElement;
    allInputs.push(name);
    let phone = document.getElementById("phone") as HTMLInputElement;
    allInputs.push(phone);
    let email = document.getElementById('email') as HTMLInputElement;
    allInputs.push(email)
    let  login = document.getElementById('login') as HTMLInputElement;
    allInputs.push(login);
    let birth = document.getElementById('birth') as HTMLInputElement;
    allInputs.push(birth);
    let pass = document.getElementById('password') as HTMLInputElement;
    allInputs.push(pass);
    let doc= document.getElementById('document') as HTMLInputElement;
    allInputs.push(doc);

    allInputs.forEach(function(prop){
      if(prop.value == ""){
        console.log(prop);
        console.log("aa")
      }

    });
    // if(name !=null){
    //   console.log(name)
    // }
    // var data = JSON.stringify({
    //   "name" : name.value,
    // }
  }
}






