import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }

  url:string = 'https://localhost:7059';

  getUser(id: number) {
    return this.http.get<User[]>(this.url+`/api/Admin/getUser/${id}`);
  }

  deleteUser(id: number){
    return this.http.delete<User>(this.url + `/api/Admin/deleteUser/${id}`);
  }

  approveClient(id: number){
    return this.http.post(this.url + `/api/Admin/clientId/${id}`,id);
  }
}

