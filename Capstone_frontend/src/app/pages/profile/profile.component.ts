import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {  MatTableModule } from '@angular/material/table';
import { Router,  } from '@angular/router';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [FormsModule,MatTableModule, MatButtonModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {
  expandedSubmission: any;
  // Example data structure for submissions
  submissions = [
  {
    date: '2024-11-01',
    totalEmissions: 150,
    details: [
      { category: 'Household', item: 'Electricity', usage: 500, emissions: 100 },
      { category: 'Transport', item: 'Petrol', usage: 20, emissions: 50 },
      { category: 'Waste', item: 'Recycled', usage: 15, emissions: 10 },
    ]
  },
  {
    date: '2024-10-20',
    totalEmissions: 200,
    details: [
      { category: 'Household', item: 'Coal', usage: 100, emissions: 150 },
      { category: 'Transport', item: 'Diesel', usage: 30, emissions: 40 },
      { category: 'Waste', item: 'Landfill', usage: 20, emissions: 30 },
    ]
  }
];

  
  router = inject(Router);
  user = JSON.parse(localStorage.getItem("user") || "null");
  
  updateProfile() {
   this.router.navigateByUrl('updateprofile');
  }
  expandRow(submission: any): void {
    this.expandedSubmission = this.expandedSubmission === submission ? null : submission;
  }

  // editSubmission(_t43: any) {
  //   throw new Error('Method not implemented.');
  // }

}
