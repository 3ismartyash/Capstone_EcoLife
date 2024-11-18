import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {  MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-dash-board',
  standalone: true,
  imports: [MatButtonModule,MatTableModule],
  templateUrl: './dash-board.component.html',
  styleUrl: './dash-board.component.css'
})
export class DashBoardComponent {
allSubmissions: any= [
  {
    userName: 'John Doe',
    userEmail: 'john.doe@example.com',
    date: '2024-11-17',
    totalEmissions: 120.5,
    details: [
      { category: 'Household', item: 'Electricity', usage: '350 kWh', emissions: 80.5 },
      { category: 'Transport', item: 'Petrol', usage: '40 liters', emissions: 30 },
      { category: 'Waste', item: 'Landfill', usage: '20 kg', emissions: 10 }
    ]
  },
  {
    userName: 'Jane Smith',
    userEmail: 'jane.smith@example.com',
    date: '2024-11-16',
    totalEmissions: 95.3,
    details: [
      { category: 'Household', item: 'Electricity', usage: '250 kWh', emissions: 50 },
      { category: 'Transport', item: 'Diesel', usage: '30 liters', emissions: 25 },
      { category: 'Waste', item: 'Recycled', usage: '15 kg', emissions: 5.3 }
    ]
  },
  {
    userName: 'Michael Johnson',
    userEmail: 'michael.johnson@example.com',
    date: '2024-11-15',
    totalEmissions: 200.0,
    details: [
      { category: 'Household', item: 'Coal', usage: '50 kg', emissions: 60 },
      { category: 'Transport', item: 'CNG', usage: '15 kg', emissions: 10 },
      { category: 'Waste', item: 'Compost', usage: '25 kg', emissions: 5 }
    ]
  }
];;
expandedSubmission: any;
deleteSubmission(_t32: any) {
throw new Error('Method not implemented.');
}
expandRow(submission: any) {
  this.expandedSubmission = submission; // Store expanded submission data
}


}
