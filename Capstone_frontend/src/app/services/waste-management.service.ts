import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WasteManagementService {

  constructor(private http:HttpClient) { }
 

  getById(userid:Number)
  {
    return this.http.get("https://localhost:3005/wastemanagement/"+userid);
  }
  

  add(waste:any)
  {
    return this.http.post("https://localhost:3005/wastemanagement",waste);
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
