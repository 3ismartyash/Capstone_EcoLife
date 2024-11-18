import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { delay } from 'rxjs';

@Component({
  selector: 'app-update-profile',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './update-profile.component.html',
  styleUrl: './update-profile.component.css'
})
export class UpdateProfileComponent {

  user = JSON.parse(localStorage.getItem("user") || "null");
  updateduser = {
    name: this.user.name,
    email: this.user.email,
    phoneNumber: this.user.phoneNumber
  }
  confirmation =
    {
      username: this.user.email,
      password: ""
    }
  errorMessage = "";
  isConfirm = false;
  Confimed = false;
  Message = "Updated details successfully";

  authService = inject(UserService);
  router = inject(Router);

  profilepage() {
    this.router.navigateByUrl("profile");
    }

  confirmPassword() {
    this.Confimed=false;
    this.isConfirm=false;
    this.authService.login(this.confirmation).subscribe(
      {
        next: (res) =>{
          this.authService.update(this.user.id, this.updateduser).subscribe({
            next: (response : any) =>{
              this.Confimed = true;
              console.log(response);
              localStorage.setItem("user", JSON.stringify(response.result));
            },
            error : (err)=>{
              this.errorMessage="Couldn't update the profile, Try Again!"
              this.isConfirm=true;
            }
          })
        },
        error: (err) =>{
          this.errorMessage="Wrong password ,Try Again!"
          this.isConfirm=true;
        }
      }
    );
  }
}
