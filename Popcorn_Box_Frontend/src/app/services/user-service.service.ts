import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IUser } from '../models/IUser';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  constructor(private http: HttpClient) { }
  Register(user: IUser) {
    return this.http.post<IUser>('https://localhost:7059/api/User/register', user);
  }

  Login(Email: string, Password: string) {
    return this.http.post('https://localhost:7059/login/' + Email + ',' + Password, Password);
  }

  PendingApprovals() {
    return this.http.get('https://localhost:7059/pedingAprovals');
  }

  IsLoggedin(): boolean {
    return localStorage.getItem('jwt') != null;
  }

  DecodeToken() {
    if (localStorage.getItem('jwt') != null && localStorage.getItem('jwt') != '') {
      const token: string = localStorage.getItem('jwt') ?? '';
      const extractedToken: string = token.split('.')[1];
      const _atobData = atob(extractedToken);
      const finalData = JSON.parse(_atobData);
      if (finalData.Role == 'Admin') {
        return true;
      }
      else {
        return false;
      }
    }
    else {
      return false;
    }
  }
  IsClient(): boolean {
    if (localStorage.getItem('jwt') != null && localStorage.getItem('jwt') != '') {
      const token: string = localStorage.getItem('jwt') ?? '';
      const extractedToken: string = token.split('.')[1];
      const _atobData = atob(extractedToken);
      const finalData = JSON.parse(_atobData);
      if (finalData.Role == 'Client') {
        return true;
      }
      else {
        return false;
      }
    }
    else {
      return false;
    }
  }
  GetUserId() {
    if (localStorage.getItem('jwt') != null && localStorage.getItem('jwt') != '') {
      const token: string = localStorage.getItem('jwt') ?? '';
      const extractedToken: string = token.split('.')[1];
      const _atobData = atob(extractedToken);
      const finalData = JSON.parse(_atobData);
      return finalData.Id;
    }
    else {
      -999;
    }
  }
  
  IsAdmin(): boolean {
    if (localStorage.getItem('jwt') != null && localStorage.getItem('jwt') != '') {
      let token: string = localStorage.getItem('jwt') ?? '';
      let extractedToken: string = token.split('.')[1];
      let _atobData = atob(extractedToken);
      let finalData = JSON.parse(_atobData);
      if (finalData.Role == 'Admin') {
        return true;
      }
      else {
        return false;
      }
    }
    else {
      return false;
    }
  }
  GetUserById(id:number){
    return this.http.get<IUser>('https://localhost:7059/get/user/'+id);
  }
  UpdateUser(id:number, user:IUser){
    return this.http.patch<IUser>('https://localhost:7059/user/'+id,user);
  }
}
