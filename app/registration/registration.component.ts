import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../vehicle.service';
import { RegistrationData } from '../RegistrationData';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  
  constructor( private _regService : VehicleService ) {
    
   }

  registrationdata : RegistrationData = new RegistrationData(0,null,null,null,null,null,null,null,null,null,null,0,null,null,null,null,null,null,null);

  ngOnInit() {
  }

  addRegData(){

    this._regService.addRegistrationDetails(this.registrationdata).subscribe();
  }

  submitted = false;
  inserted = false;

  onSubmit(frm:any) {
  this.submitted = true; 
  console.log(frm.valid);
  if(!frm.valid)
  {
    return;
  }
  else
  {
    this.addRegData();
    this.inserted = true;
  }
  //console.log((this.registrationdata));
  
  }
}
