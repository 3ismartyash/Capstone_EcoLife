import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent {
  router = inject(Router);
  user = JSON.parse(localStorage.getItem("user") || "null");
  editSubmission(_t43: any) {
    throw new Error('Method not implemented.');
  }


  submissions: any;

  updateProfile() {
   this.router.navigateByUrl('updprofile');
  }


}
