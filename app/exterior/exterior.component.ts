import { Component, OnInit } from '@angular/core';
import { IConfiguration } from '../IConfiguration';
import { IAlternate } from '../IAlternate';
import { IVariant } from '../IVariant';
import { VehicleService } from '../vehicle.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-exterior',
  templateUrl: './exterior.component.html',
  styleUrls: ['./exterior.component.css']
})
export class ExteriorComponent implements OnInit {

  constructor( private vehicle : VehicleService, private router:Router) { }

  default : IConfiguration[];
  extconfig : IConfiguration[];
  alt : IAlternate[];
  varList : IVariant[];
  varid : string;
  prices:number[];
  ngOnInit() {

    if (localStorage.getItem('varid')===null)
    {
      this.varid = null;
    }
    else
    {
      this.varid = JSON.parse(localStorage.getItem('varid'));
    }

    this.total = parseInt((localStorage.getItem('itotal')));
    this.vehicle.getDefaultFeatureByVarId(this.varid).subscribe( (data) => this.default = data);

    this.vehicle.getVariantByVarId( this.varid ).subscribe( (data) => this.varList = data);

    this.vehicle.getExteriorConfigurableByVarId( this.varid ).subscribe( (data) =>{ this.extconfig = data;
    
      this.prices = new Array(this.extconfig.length);

      this.extconfig.forEach( (value, index) =>
      {
        this.prices[index] = 0;
      })
    });
  }
  total:number = parseInt(localStorage.getItem('baseprice'));
  getAltDesp( confid : string)
  {
    this.vehicle.getAltDespByConfId(confid).subscribe( (data) => this.alt = data);
  }

  managePrice(price,a,i)
  {
    this.prices[i] = price.target.value;
    this.recalculateTotalPrice();
    localStorage.setItem('etotal',this.total.toString());
    localStorage.setItem('temp',this.total.toString());
  }

  recalculateTotalPrice()
  {
    this.total = parseInt((localStorage.getItem('itotal')));
    this.prices.forEach( (value, index) => {
      console.log( typeof value);
      let temp= +value;
      console.log( typeof temp);
      this.total = this.total+temp;
    })
  }

  invoice()
  {
      this.router.navigate(['/invoice']);
  }

}
