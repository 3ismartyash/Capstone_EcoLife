import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  getUsers()
  {
    return this.http.get("https://localhost:3005/auth/users");
  }
  
  login(userobj: any)
  {
    return this.http.post("https://localhost:3005/auth/login",userobj);
  }

  register(regobj: any)
  {
    return this.http.post("https://localhost:3005/auth/register",regobj);
  }

  update(id:Number,updateobj: any)
  {
    return this.http.put("https://localhost:3005/auth/update/"+id,updateobj);
  }
}
