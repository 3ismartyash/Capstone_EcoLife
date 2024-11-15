import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WasteManagementService {

  constructor(private http:HttpClient) { }
  // getAll()
  // {
  //   return this.http.get("");
  // }

  // getById()
  // {
  //   return this.http.get("");
  // }

  add(waste:any)
  {
    return this.http.post("https://localhost:3004/api/WasteManagement",waste);
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
