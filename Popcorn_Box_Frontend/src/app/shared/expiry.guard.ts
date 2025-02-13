import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';

export const expiryGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);

  const token = localStorage.getItem('jwt');
  const payLoad = atob(token?.split('.')[1] ?? '');
  const parseToken = JSON.parse(payLoad || '')

  if(!(parseToken.exp > Date.now()/1000)){
    alert('Session Expired!!! Please Login Again');
    router.navigate(['/login']);
  }
  
  return true;
};
