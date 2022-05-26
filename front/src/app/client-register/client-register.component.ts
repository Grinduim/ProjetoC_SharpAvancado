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
  // constructor(private formBuilder: FormBuilder) {
  //   this.clientForms = this.formBuilder.group({
  //     'name': ['', [Validators.required, Validators.minLength(3)]],
  //     'phone': ['', [Validators.required]],
  //     'email': ['', [Validators.required, Validators.email]],
  //     'document':['',[Validators.required]],
  //     'birth':['',[Validators.required]],
  //     'login':['',[Validators.required]],
  //     'password':['',[Validators.required]]
  //   });
  // }

  ngOnInit(): void {

  }

  VerifyForm() {
    console.log("Loo")
    var nameInput = document.querySelector("#name");
    if(nameInput?.textContent == ""){
      this.activeVisibleSpan("#name-none")
    }
  }

  activeVisibleSpan(id: string){
    var span = document.querySelector(id);
    span?.classList.remove('invisible');
    console.log("aaa")
  }


}
