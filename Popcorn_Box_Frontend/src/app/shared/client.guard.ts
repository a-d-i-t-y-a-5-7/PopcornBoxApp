import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { UserServiceService } from '../services/user-service.service';

export const clientGuard: CanActivateFn = (route, state) => {
  const service = inject(UserServiceService);
  const router = inject(Router);
  if(service.IsClient()){
    return true;
  }
  else{
    alert('You dont have access to this page');
    router.navigate(['home']);
    return false;
  }
};
