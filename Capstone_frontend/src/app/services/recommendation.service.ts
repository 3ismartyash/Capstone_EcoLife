import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RecommendationService {

  constructor(private http : HttpClient) { }

  getById(userid:Number)
  {
    return this.http.get("https://localhost:3005/recommendation/"+userid);
  }
  add(recommend: any)
  {
     return this.http.post("https://localhost:3005/recommendation",recommend);
  } 
}
