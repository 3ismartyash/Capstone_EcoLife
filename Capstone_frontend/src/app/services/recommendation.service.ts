import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RecommendationService {

  constructor(private http : HttpClient) { }

  add(recommend: any)
  {
     return this.http.post("https://localhost:7236/api/Recommendation",recommend);
  }
}
