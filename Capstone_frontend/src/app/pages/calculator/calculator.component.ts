import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HouseHoldService } from '../../services/house-hold.service';
import { TransportService } from '../../services/transport.service';
import { WasteManagementService } from '../../services/waste-management.service';
import { MatDialog } from '@angular/material/dialog';
import { RecommendationsComponent } from '../recommendations/recommendations.component';
import { RecommendationService } from '../../services/recommendation.service';
import { forkJoin } from 'rxjs';

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

  
  user = JSON.parse(localStorage.getItem("user") || "null");

  household: any = {
    "userid": Number(this.user.id),
    "electricityUsage": 0.0,
    "lpgUsage": 0.0,
    "coalUsage": 0.0,
    "RecordedDate": ""
  };
  transportation: any = {
    "userid": Number(this.user.id),
    "petrolUsage": 0.0,
    "dieselUsage": 0.0,
    "cngUsage": 0.0,
    "RecordedDate":""
  };
  wasteManagement: any = {
    "userid": Number(this.user.id),
    "recycledWaste": 0.0,
    "compostWaste": 0.0,
    "landfillWaste": 0.0,
    "RecordedDate":""
  }

  totalemission: any =
    {
      "userId": Number(this.user.id),
      "totalEmissions": 0,
      "recordedDate": ""
    }

  emissionData: any = {
    category: '',
    bgColor: '',
    recommendationMessage: '',
  };

  onSubmit() {
    
    const householdObs = this.housholdService.add(this.household);
    const transportObs = this.transportService.add(this.transportation);
    const wasteObs = this.wasteManagementService.add(this.wasteManagement);

    forkJoin([householdObs, transportObs, wasteObs]).subscribe(
      ([householdRes, transportRes, wasteRes]: any) => {
        this.totalemission.totalEmissions =0;
        this.totalemission.totalEmissions += householdRes.houseHoldEmission+transportRes.transportEmission+ wasteRes.wasteEmission;

        this.recommendationService.add(this.totalemission).subscribe((res: any) => {
          this.emissionData.category = res.category;
          this.emissionData.recommendationMessage = res.message;

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
              this.emissionData.bgColor = 'white'; 
          }

          this.dialog.open(RecommendationsComponent, {
            data: this.emissionData,
          });
        });
      }
    );

  }

}


