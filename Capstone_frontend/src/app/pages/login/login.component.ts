import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  role ="";
  userobj: any = {
    username: 'sim@gmail.com',
    password: 'Sim@123'
  };

  regobj: any = {
    email:'Def@gmail.com',
    name:'def',
    phonenumber:'789',
    password:'Def@123'
    
  };

  http = inject(HttpClient);
  router = inject(Router)

  onRegister() {
    console.log(this.regobj.password);
    this.http.post("https://localhost:3001/api/AuthApi/Register",this.regobj).subscribe((res: any) => {
      alert("Register Success");
      if (res)
      { 
        this.router.navigateByUrl('home');
        localStorage.setItem("role",res.result);
        this.role = res.result;
      }
      else
        alert(res.message);
    })  }
  onLogin() {

    this.http.post("https://localhost:3001/api/AuthApi/Login",this.userobj).subscribe((res: any) => {
      if (res.result)
      {
        alert("Login Success");
        this.router.navigateByUrl('home');
        localStorage.setItem("token", res.result.token);
        localStorage.setItem("role",res.result.role);
        this.role = res.result.role;
      }
      else
        alert(res.message);
    })
  }

}

