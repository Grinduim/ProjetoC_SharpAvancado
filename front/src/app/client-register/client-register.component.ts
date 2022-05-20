import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgModel } from '@angular/forms';
//import { Client } from '../client';
import { Client } from '../client';
@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css'],
})
export class ClientRegisterComponent implements OnInit {
  clientForms: FormGroup;


  constructor(private formBuilder: FormBuilder) {
    this.clientForms = this.formBuilder.group({
      'name': ['', [Validators.required, Validators.minLength(3)]],
      'phone': ['', [Validators.required]],
      'email': ['', [Validators.required, Validators.email]],
      'document':['',[Validators.required]],
      'birth':['',[Validators.required]],
      'login':['',[Validators.required]],
      'password':['',[Validators.required]]
    });
  }

  ngOnInit(): void {
  }

  VerifyForm() {
    // let allInputs: Array<any> = [];
    // let name = document.getElementById('name') as HTMLInputElement;
    // this.clientForms.name = name.value;
    // let phone = document.getElementById('phone') as HTMLInputElement;
    // allInputs.push(phone);
    // let email = document.getElementById('email') as HTMLInputElement;
    // allInputs.push(email);
    // let login = document.getElementById('login') as HTMLInputElement;
    // allInputs.push(login);
    // let birth = document.getElementById('birth') as HTMLInputElement;
    // allInputs.push(birth);
    // let pass = document.getElementById('password') as HTMLInputElement;
    // allInputs.push(pass);
    // let doc = document.getElementById('document') as HTMLInputElement;
    // allInputs.push(doc);

    // allInputs.forEach(function (prop) {
    //   if (prop.value) {
    //     console.log(prop);
    //     console.log('aa');
    //   }
    // });
    // if(name !=null){
    //   console.log(name)
    // }
    // var data = JSON.stringify({
    //   "name" : name.value,
    // }

    console.log("Chamou");
    if(!this.clientForms.valid){
      console.log("Errouu")

    }
    console.log(this.clientForms.value)
  }


}
