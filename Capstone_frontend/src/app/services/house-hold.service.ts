import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HouseHoldService {

  constructor(private http:HttpClient) { }
  getAll()
  {
    return this.http.get("https://localhost:3002/api/HouseHold/all");
  }

  getById(userid:any)
  {
    return this.http.get("https://localhost:3002/api/HouseHold/"+userid); 
  }

  add(household:any)
  {
    return this.http.post("https://localhost:3002/api/HouseHold",household);
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
