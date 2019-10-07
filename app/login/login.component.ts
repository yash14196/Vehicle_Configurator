import { Component, OnInit } from '@angular/core';
import { RegistrationData } from '../RegistrationData';
import { VehicleService } from '../vehicle.service';
import { IRegistration } from '../IRegistration';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  submitted=false;
  userid= null;
  //islogged = false;
  constructor( private _loginService : VehicleService , private router:Router) { }

  registrationdata : RegistrationData = new RegistrationData(0,null,null,null,null,null,null,null,null,null,null,0,null,null,null,null,null,null,null);

  sendCredentials() 
  {
    this._loginService.checkCredentials(this.registrationdata).subscribe( (data) =>{ this.userid = data;
      console.log(this.userid);
      
      localStorage.setItem( 'companyid', JSON.stringify(this.userid));

      if(data)
      {
        this.submitted=true;
        this._loginService.userlogindone(this.submitted);
        this.router.navigate(['/home'],{ state : { uid: this.userid} });
      }
    
    });
    
  }


  onSubmit()
  {
    
    this.sendCredentials();
        
  }
  ngOnInit() {
  }

  /*chklogin()
  {
    this.islogged = true;
   /* if (this.userid)
    { 
      this._loginService.userlogindone(this.islogged);
    //} 
  }
  */
}
