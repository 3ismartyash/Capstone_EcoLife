import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  userService = inject(UserService);
  router = inject(Router);
  role = "";
  isRegisterMode = false;
  userobj: any = {
    "username": 'sim@gmail.com',
    "password": 'Sim@123'
  };
  regobj: any = {
    "email": 'Def@gmail.com',
    "name": 'def',
    "phonenumber": '789',
    "password": 'Def@123'

  };

  switchToRegister(event: MouseEvent) 
  {
    event.preventDefault();  // Prevents the default link behavior
    this.isRegisterMode = true;
    }   

  onRegister() {
    this.userService.register(this.regobj).subscribe((res: any) => {
      if (res.isSuccess) {
        alert("Register Success");
        this.isRegisterMode = false;
      }
      else
        alert(res.message);
    })
  }

  onLogin() {
    this.userService.login(this.userobj).subscribe((res: any) => {
      if (res.isSuccess) {
        alert("Login Success");
        this.router.navigateByUrl('home');
        localStorage.setItem("user",JSON.stringify(res.result.user));
        localStorage.setItem("token", res.result.token);
        localStorage.setItem("role", res.result.role);
        this.role = res.result.role;
      }
      else
        alert(res.message);
    })
  }

}