import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA,  MatDialogModule } from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-recommendations',
  standalone: true,
  imports: [MatDialogModule,CommonModule,MatIcon],
  templateUrl: './recommendations.component.html',
  styleUrl: './recommendations.component.css'
})
export class RecommendationsComponent {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}
  getLightColor(color: string): string {
    switch (color) {
      case 'green': return '#e8f5e9'; // Light green
      case 'blue': return '#e3f2fd'; // Light blue
      case 'orange': return '#ffe0b2'; // Light orange
      case 'yellow': return '#fff9c4'; // Light yellow
      case 'red': return '#ffebee'; // Light red
      case 'darkred': return '#ffcccb'; // Light dark red
      default: return '#ffffff'; // Default light color (white)
    }
  }
  
  getDarkColor(color: string): string {
    switch (color) {
      case 'green': return '#388e3c'; // Dark green
      case 'blue': return '#1976d2'; // Dark blue
      case 'orange': return '#f57c00'; // Dark orange
      case 'yellow': return '#fbc02d'; // Dark yellow
      case 'red': return '#d32f2f'; // Dark red
      case 'darkred': return '#c62828'; // Dark dark red
      default: return '#000000'; // Default dark color (black)
    }
  }
  
}
 