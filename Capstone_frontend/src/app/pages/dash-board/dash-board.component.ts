import { Component, OnInit, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {  MatTableModule } from '@angular/material/table';
import { UserService } from '../../services/user.service';
import { forkJoin } from 'rxjs';
import { HouseHoldService } from '../../services/house-hold.service';
import { TransportService } from '../../services/transport.service';
import { WasteManagementService } from '../../services/waste-management.service';
import { RecommendationService } from '../../services/recommendation.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dash-board',
  standalone: true,
  imports: [CommonModule,MatButtonModule,MatTableModule],
  templateUrl: './dash-board.component.html',
  styleUrl: './dash-board.component.css'
})
export class DashBoardComponent implements OnInit{
users: any;
viewSubmissions(userId: number) {
  this.showCategory('household');
  this.selectedUser={
    household:[],
    transport : [],
    waste:[]
  };
  if(this.selectedCategory='household')
  {
    this.housholdService.getById(userId).subscribe((userData) => {
      this.selectedUser.household = userData;
    });
  }
  if(this.selectedCategory='transport')
  {
    this.transportService.getById(userId).subscribe((userData) => {
      this.selectedUser.transport = userData;
      console.log(userData);
    });
  }
  if(this.selectedCategory='waste')
  {
    this.wasteManagementService.getById(userId).subscribe((userData) => {
      this.selectedUser.waste = userData;
      console.log(userData);

    });
  }
  
}

showCategory(category: string) {
  this.selectedCategory = category;
}

closeModal() {
  this.selectedUser = undefined;
  this.selectedCategory = null;
}
selectedCategory: any;
selectedUser: any;
  ngOnInit(): void {
    this.userService.getUsers().subscribe((res:any)=>{
      this.users= res.result;
    });
  }

  userService = inject(UserService);
 
  housholdService= inject(HouseHoldService);
  transportService=inject(TransportService);
  wasteManagementService=inject(WasteManagementService);
  recommendationService = inject(RecommendationService);


}