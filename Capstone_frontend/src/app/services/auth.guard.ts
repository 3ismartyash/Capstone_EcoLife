import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core'

export const authGuard: CanActivateFn = (route, state) => {

  const router = inject(Router);

  const token = localStorage.getItem("token");
  const role = localStorage.getItem("role");

  if (token != null) {
    if (route.data['role']) {
      if (route.data['role'] === role) { return true; }
      else { 
        router.navigateByUrl("home")
        return false;
      }
    }
    return true;
  }
  router.navigateByUrl("login")
  return false;

};
