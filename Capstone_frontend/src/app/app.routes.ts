import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { NavBarComponent } from './pages/nav-bar/nav-bar.component';
import { AboutComponent } from './pages/about/about.component';
import { CalculatorComponent } from './pages/calculator/calculator.component';
import { DashBoardComponent } from './pages/dash-board/dash-board.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { UpdateProfileComponent } from './pages/update-profile/update-profile.component';
import { RecommendationsComponent } from './pages/recommendations/recommendations.component';
import { authGuard } from './services/auth.guard';
import { AirQualityComponent } from './pages/air-quality/air-quality.component';

export const routes: Routes = [
    {path:"",redirectTo:"login",pathMatch:'full'},
    {path:"login",component:LoginComponent},
    {path:"", component:NavBarComponent,
        children:[
            {path:"home",component: HomeComponent,canActivate:[authGuard]},
            {path:"about",component:AboutComponent,canActivate:[authGuard]},
            {path:"calculate",component:CalculatorComponent,canActivate:[authGuard]},
            {path:"dashboard",component:DashBoardComponent,canActivate:[authGuard],data:{role :"Admin"}},
            {path:"profile",component:ProfileComponent,canActivate:[authGuard]},
            {path:"updateprofile",component:UpdateProfileComponent,canActivate:[authGuard]},
            {path:"recmd",component:RecommendationsComponent,canActivate:[authGuard]},
            {path:"airquality",component:AirQualityComponent}
        ]},
     
];
