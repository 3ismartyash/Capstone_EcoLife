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

  // getById()
  // {
  //   return this.http.get("");
  // }

 add(transport:any)
  {
    return this.http.post("https://localhost:3003/api/Transportation",transport);
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
