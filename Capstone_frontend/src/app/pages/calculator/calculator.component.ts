import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HouseHoldService } from '../../services/house-hold.service';
import { TransportService } from '../../services/transport.service';
import { WasteManagementService } from '../../services/waste-management.service';

@Component({
  selector: 'app-calculator',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './calculator.component.html',
  styleUrl: './calculator.component.css'
})
export class CalculatorComponent {

  housholdService = inject(HouseHoldService);
  transportService = inject(TransportService);
  wasteManagementService = inject(WasteManagementService);

  recDate = new Date();
  userid = localStorage.getItem("userid");

  household: any = {
    "userid": Number(this.userid),
    "electricityUsage":0.0,
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
  onSubmit() {
    
    this.housholdService.add(this.household).subscribe((res:any)=>
    {
      console.log(res);
    });
    this.transportService.add(this.transportation).subscribe((res:any)=>
    {
      console.log(res);
    });
    this.wasteManagementService.add(this.wasteManagement).subscribe((res:any)=>
    {
      console.log(res);
    });
  }


}
