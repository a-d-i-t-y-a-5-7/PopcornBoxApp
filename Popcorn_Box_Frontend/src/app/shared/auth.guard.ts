import { CanActivateFn, Router } from '@angular/router';
import { UserServiceService } from '../services/user-service.service';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  const service = inject(UserServiceService);
  const router = inject(Router);
  if(service.IsLoggedin()){
    return true;    
  }
  else{
    router.navigate(['login']);
    return false;
  }
};
