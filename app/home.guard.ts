import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { VehicleService } from './vehicle.service';

@Injectable({
  providedIn: 'root'
})
export class HomeGuard implements CanActivate {

  constructor ( private _vehicle : VehicleService)
  {}

  canActivate()
  
    {
      var r = this._vehicle.userloginchk();
      return r;
    } 
}
