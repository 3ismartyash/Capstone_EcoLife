import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HouseHoldService {

  constructor(private http:HttpClient) { }
  

  getById(userid:any)
  {
    return this.http.get("https://localhost:3005/household/"+userid); 
  }

  add(household:any)
  {
    return this.http.post("https://localhost:3005/household",household);
  }

  // update()
  // {
  //   return this.http.put("",);
  // }

  // delete()
  // { 
  //   return this.http.delete(""); 
  // }
}
