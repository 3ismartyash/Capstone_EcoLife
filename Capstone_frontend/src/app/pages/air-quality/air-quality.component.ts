import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AirQualityService } from '../../services/air-quality.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-air-quality',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './air-quality.component.html',
  styleUrl: './air-quality.component.css'
})
export class AirQualityComponent {
  city = 'Hyderabad'; // Default city
  airQualityData: any = null; // Holds the API response
  cities = ['Hyderabad', 'Delhi', 'Mumbai', 'Bangalore', 'Chennai']; // Available cities

  airQualityService = inject(AirQualityService);
  constructor() {}

  ngOnInit(): void {
    this.fetchAirQuality(); // Fetch data for the default city
  }

  // Fetch air quality data for the selected city
  fetchAirQuality(): void {
    this.airQualityService.getAirQuality(this.city).subscribe(
      (response :any) => {
        
          console.log(response);
          this.airQualityData = response.data;
        
      },
      (error:any) => {
        console.error('Error fetching air quality data:', error);
      }
    );
  }
}
