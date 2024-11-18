import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  login(userobj: any)
  {
    return this.http.post("https://localhost:3001/api/AuthApi/Login",userobj);
  }

  register(regobj: any)
  {
    return this.http.post("https://localhost:3001/api/AuthApi/Register",regobj);
  }

  update(id:Number,updateobj: any)
  {
    return this.http.put("https://localhost:3001/api/AuthApi/Update/"+id,updateobj);
  }
}
