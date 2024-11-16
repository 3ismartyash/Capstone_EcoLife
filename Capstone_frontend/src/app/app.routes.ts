import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { NavBarComponent } from './pages/nav-bar/nav-bar.component';
import { AboutComponent } from './pages/about/about.component';
import { CalculatorComponent } from './pages/calculator/calculator.component';
import { DashBoardComponent } from './pages/dash-board/dash-board.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { UpdateProfileComponent } from './pages/update-profile/update-profile.component';

export const routes: Routes = [
    {path:"",redirectTo:"login",pathMatch:'full'},
    {path:"login",component:LoginComponent},
    {path:"", component:NavBarComponent,
        children:[
            {path:"home",component: HomeComponent},
            {path:"about",component:AboutComponent},
            {path:"calculate",component:CalculatorComponent},
            {path:"dashboard",component:DashBoardComponent},
            {path:"profile",component:ProfileComponent},
            {path:"updprofile",component:UpdateProfileComponent}
        ]},
    
];
