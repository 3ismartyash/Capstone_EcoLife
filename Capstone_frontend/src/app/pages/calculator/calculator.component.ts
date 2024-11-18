import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HouseHoldService } from '../../services/house-hold.service';
import { TransportService } from '../../services/transport.service';
import { WasteManagementService } from '../../services/waste-management.service';
import { MatDialog } from '@angular/material/dialog';
import { RecommendationsComponent } from '../recommendations/recommendations.component';
import { RecommendationService } from '../../services/recommendation.service';

@Component({
  selector: 'app-calculator',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './calculator.component.html',
  styleUrl: './calculator.component.css'
})
export class CalculatorComponent {

  constructor(public dialog: MatDialog) { }
  
  housholdService = inject(HouseHoldService);
  transportService = inject(TransportService);
  wasteManagementService = inject(WasteManagementService);
  recommendationService = inject(RecommendationService);

  recDate = new Date();
  userid = localStorage.getItem("userid");

  
  household: any = {
    "userid": Number(this.userid),
    "electricityUsage": 0.0,
    "lpgUsage": 0.0,
    "coalUsage": 0.0,

  };
  transportation: any = {
    "userid": Number(this.userid),
    "petrolUsage": 0.0,
    "dieselUsage": 0.0,
    "cngUsage": 0.0,

  };
  wasteManagement: any = {
    "userid": Number(this.userid),
    "recycledWaste": 0.0,
    "compostWaste": 0.0,
    "landfillWaste": 0.0,

  }
  
  totalemission : any =
  {
    "userId": Number(this.userid),
    "totalEmissions": 0,
    "recordedDate": "2024-11-18"
  }

  emissionData: any = {
    category: '',
    bgColor: '',
    recommendationMessage: '',
  };

  onSubmit() {

    this.housholdService.add(this.household).subscribe((res:any)=>
    {
      this.totalemission.totalEmissions+=res.houseHoldEmission;
      localStorage.setItem("householdemissions",res.houseHoldEmission);
    });
    this.transportService.add(this.transportation).subscribe((res: any) => {
      this.totalemission.totalEmissions += res.transportEmission;
      localStorage.setItem("transportemissions", res.transportEmission);
    });
    this.wasteManagementService.add(this.wasteManagement).subscribe((res: any) => {
      this.totalemission.totalEmissions += res.wasteEmission;
      localStorage.setItem("wasteemissions", res.wasteEmission);
    });
    console.log(this.totalemission)
    this.recommendationService.add(this.totalemission).subscribe((res: any)=>
    {
      this.emissionData.category = res.category;
      this.emissionData.recommendationMessage = res.message;
    })
   

    switch (this.emissionData.category) {
      case 'Good':
        this.emissionData.bgColor = 'green';
        break;
      case 'Satisfactory':
        this.emissionData.bgColor = 'blue';
        break;
      case 'Moderate':
        this.emissionData.bgColor = 'orange';
        break;
      case 'Poor':
        this.emissionData.bgColor = 'yellow';
        break;
      case 'Very Poor':
        this.emissionData.bgColor = 'red';
        break;
      case 'Severe':
        this.emissionData.bgColor = 'darkred';
        break;
      default:
        this.emissionData.bgColor = 'white'; // Default color
    }

    this.dialog.open(RecommendationsComponent, {
      data: this.emissionData,
    });
  }

}


