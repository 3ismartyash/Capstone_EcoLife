import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import {  MatTableModule } from '@angular/material/table';
import { Router,  } from '@angular/router';
import { HouseHoldService } from '../../services/house-hold.service';
import { TransportService } from '../../services/transport.service';
import { WasteManagementService } from '../../services/waste-management.service';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [FormsModule,MatTableModule, MatButtonModule,CommonModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit {
  ngOnInit(): void {
    this.fetchSubmissions();
  }
  
  
  updateProfile() {
   this.router.navigateByUrl('updateprofile');
  }
  selectedCategory: string = 'household';


  router = inject(Router);
  housholdService= inject(HouseHoldService);
  transportService=inject(TransportService);
  wasteManagementService=inject(WasteManagementService);
  user = JSON.parse(localStorage.getItem("user") || "null");
  userSubmissions: any;
  
  fetchSubmissions() {
    this.userSubmissions={
      household:[],
    transport : [],
    waste:[]
    };
    console.log(Number(this.user.id));
    // Fetch household data
    this.housholdService.getById(Number(this.user.id)).subscribe({
      next: (data) => {this.userSubmissions.household = data},
      error: (err) => console.error('Error fetching household data:', err)
    });

    // Fetch transport data
    this.transportService.getById(Number(this.user.id)).subscribe({
      next: (data) => (this.userSubmissions.transport = data),
      error: (err) => console.error('Error fetching transport data:', err)
    });

    // Fetch waste data
    this.wasteManagementService.getById(Number(this.user.id)).subscribe({
      next: (data) => (this.userSubmissions.waste = data),
      error: (err) => console.error('Error fetching waste data:', err)
    });

  

}

}
