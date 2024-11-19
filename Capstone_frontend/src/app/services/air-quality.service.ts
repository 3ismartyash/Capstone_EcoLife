import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AirQualityService {

  constructor() { }
  http = inject(HttpClient);
  getAirQuality(city :string)
  {
    return this.http.get("https://localhost:3005/AirQuality/"+city);
  }
}
