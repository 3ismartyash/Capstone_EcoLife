import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TransportService {

  constructor(private http:HttpClient) { }
  // getAll()
  // {
  //   return this.http.get("");
  // }

  getById(userid:Number)
  {
    return this.http.get("https://localhost:3005/transportation/"+userid);
  }

 add(transport:any)
  {
    return this.http.post("https://localhost:3005/transportation",transport);
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
