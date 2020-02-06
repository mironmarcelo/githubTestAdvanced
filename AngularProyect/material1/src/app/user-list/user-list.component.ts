import { Component, OnInit, ViewChild } from '@angular/core';
import { UserDialogComponent } from '../user-dialog/user-dialog.component';
import { MatDialog, MatTable } from '@angular/material';
import { User } from '../models/user.model';
import { UserServiceService } from '../services/user-service.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  displayedColumns: string[] = ['userid', 'username', 'name', 'email', 'phone', 'action'];
  dataSource: any;
  @ViewChild(MatTable, { static: true }) table: MatTable<any>;

  constructor(public dialog: MatDialog, private _userService: UserServiceService) { }

  ngOnInit() {
    //this.dataSource = ELEMENT_DATA;
    this._userService.getUsers()
      .subscribe((data: any) => this.dataSource = data);
  }

  openDialog(action, obj) {
    obj.action = action;
    const dialogRef = this.dialog.open(UserDialogComponent, {
      width: '300px',
      data: {
        midata: obj,
        act: action
      }, autoFocus: false
    });

    dialogRef.afterClosed().subscribe(result => {
      //Dependiendo el evento ivoco al metodo ->
      if (result.event == 'Add') {
        this.addRowData(result.data);
      } else if (result.event == 'Update') {
        this.updateRowData(result.data);
      } else if (result.event == 'Delete') {
        this.deleteRowData(result.data);
      }
    });
  }

  addRowData(row_obj) {
    this._userService.createUser(row_obj)
      .subscribe((data: any) => {
        //Creo el objeto que se envio y lo agrego al listado ->
        this.dataSource.push({ userId: data, userName: row_obj.userName, name: row_obj.name, email: row_obj.email, phone: row_obj.phone });

        //Actualizo la tabla ->
        this.table.renderRows();
      });
  }

  updateRowData(row_obj) {
    this._userService.updateUser(row_obj)
      .subscribe((data: any) => {
        this.dataSource = this.dataSource.filter((value, key) => {
          if (value.userId == row_obj.userId) {
            value.userName = row_obj.userName;
            value.name = row_obj.name;
            value.email = row_obj.email;
            value.phone = row_obj.phone;
          }
          return true;
        });

        //Actualizo la tabla ->
        this.table.renderRows();
      });
  }

  deleteRowData(row_obj) {
    this._userService.deleteUser(row_obj.userId)
    .subscribe((data: any) => {
      this.dataSource = this.dataSource.filter((value, key) => {
        return value.userId != row_obj.userId;
      });
    });

  }

}
