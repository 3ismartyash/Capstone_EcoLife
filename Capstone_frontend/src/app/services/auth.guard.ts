import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core'

export const authGuard: CanActivateFn = (route, state) => {

  const router = inject(Router);

  const token = localStorage.getItem("token");
  const role = localStorage.getItem("role");

  if (token != null) {
    return true
    // if (route.data['role'] && route.data['role'] == role) { return true; }
    // router.navigateByUrl("home")
    // return false;
  }
  router.navigateByUrl("login")
  return false;

};
