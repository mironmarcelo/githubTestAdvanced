import { Component, Inject, Optional, OnInit  } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { User } from '../models/user.model';
import { FormBuilder, FormGroup, Validators ,FormControl } from '@angular/forms';

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.css']
})
export class UserDialogComponent implements OnInit {

  //Atributos ->
  account_validation_messages = {
    'username': [
      { type: 'required', message: 'Username es obligatorio' },
    ],
    'name': [
      { type: 'required', message: 'Username  es obligatorio' },
    ],
    'email': [
      { type: 'required', message: 'Email es obligatorio' },
      { type: 'pattern', message: 'Formato de email inválido' }
    ],
    }

  isShown: boolean = false;
  action:string;
  form: FormGroup;
  _user:User;

  //Constructor ->
  constructor(private fb: FormBuilder,
              public dialogRef: MatDialogRef<UserDialogComponent>,
              @Optional() @Inject(MAT_DIALOG_DATA) public data: any)
  {
    //Asigno los datos dele formulario ->
    this.action = data.act;
    this._user = data.midata;
  }

  //Evento OnInit ->
  ngOnInit() {
    this.isShown = false;

    //Si la accion es delete oculto los input ->
    if(this.action == "Delete") {
      this.isShown = true;
      this.form = this.fb.group({
        UserName: [this._user.userName, []],
        Name: [this._user.name, []],
        Email: [this._user.email, []],
        Phone: [this._user.phone, []],
      });
    }
    //Si la accion es update creo el form con los datos ->
    else if(this.action == "Update"){
      this.form = this.fb.group({
        UserName: [this._user.userName, [Validators.required]],
        Name: [this._user.name, [Validators.required]],
        Email: new FormControl(this._user.email, Validators.compose([
          Validators.required,
          Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
        ])),
        Phone: [this._user.phone, []],
      });
    }

     //Si la accion es update creo el form sin los datos ->
     else if(this.action == "Add"){
      this.form = this.fb.group({
        UserName: ['', [Validators.required]],
        Name: ['', [Validators.required]],
        Email: new FormControl('', Validators.compose([
          Validators.required,
          Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
        ])),
        Phone: ['', []],
      });
    }
  }

  doAction(){
    //Asigno los datos ->
    this._user.userName  = this.form.value.UserName;
    this._user.name  = this.form.value.Name;
    this._user.email  = this.form.value.Email;
    this._user.phone  = this.form.value.Phone;

    this.dialogRef.close({event:this.action, data:this._user});
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }

}
