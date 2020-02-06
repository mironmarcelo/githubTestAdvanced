import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/index";
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  //Atributos ->
  baseUrl = "http://localhost:50109/api/user";

  //Constructor ->
  constructor( private http: HttpClient) { }

  //Metodo que invoca a la api para obtener los usuarios ->
  getUsers() : Observable<User[]> {
    return this.http.get<User[]>(`${this.baseUrl}`);
  }

  //Metodo que da de alta un usuario ->
  createUser(user: User): Observable<any> {
    return this.http.post(`${this.baseUrl}`, user);
  }

  //Metodo que modifica un usuario ->
  updateUser(user: User): Observable<any> {
    return this.http.put(`${this.baseUrl}/${user.userId}`, user);
  }

  //Metodo que elimina un usuario ->
  deleteUser(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`, { responseType: 'text' });
  }
}
