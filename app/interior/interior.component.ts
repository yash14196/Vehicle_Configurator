import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../vehicle.service';
import { IConfiguration } from '../IConfiguration';
import { IAlternate } from '../IAlternate';
import { IVariant } from '../IVariant';
import { Router } from '@angular/router';

@Component({
  selector: 'app-interior',
  templateUrl: './interior.component.html',
  styleUrls: ['./interior.component.css']
})
export class InteriorComponent implements OnInit {

  constructor( private vehicle : VehicleService, private router:Router) { }

  default : IConfiguration[];
  intconfig : IConfiguration[];
  alt : IAlternate[];
  varList : IVariant[];
  varid : string;
  prices:number[];

  intTotal:number;
  gTotal:number;

  bprice : number;
  itotal : number;
  stotal : number;
  etotal : number;
  total : number;
  ngOnInit() {

    //
    /*if (localStorage.getItem('stotal')===null)
    {
      this.intTotal = parseInt(localStorage.getItem('baseprice'));
    }
    else
    {
      this.intTotal = parseInt((localStorage.getItem('stotal')));
    }  

    if (localStorage.getItem('stotal')===null)
    {
      this.stotal = 0;
    }
    else
    {
      this.stotal = parseInt(localStorage.getItem('stotal'));
    }

    if (localStorage.getItem('etotal')===null)
    {
      this.etotal = 0;
    }
    else
    {
      this.etotal = parseInt(localStorage.getItem('etotal'));
    }

    if (localStorage.getItem('itotal')===null)
    {
      this.itotal = 0;
    }
    else
    {
      this.itotal = parseInt(localStorage.getItem('itotal'));
    }

    if (localStorage.getItem('baseprice')===null)
    {
      this.bprice = 0;
    }
    else
    {
      this.bprice = parseInt(localStorage.getItem('baseprice'));
    }
    */
    //this.total = Math.max(this.bprice,this.stotal,this.itotal,this.etotal);
    console.log(this.total);

    //
    this.total = parseInt((localStorage.getItem('stotal')));
    if (localStorage.getItem('varid')===null)
    {
      this.varid = null;
    }
    else
    {
      this.varid = JSON.parse(localStorage.getItem('varid'));
    }

    this.vehicle.getDefaultFeatureByVarId(this.varid).subscribe( (data) => this.default = data);

    this.vehicle.getVariantByVarId( this.varid ).subscribe( (data) => this.varList = data);

    this.vehicle.getInteriorConfigurableByVarId( this.varid ).subscribe( (data) => {
      this.intconfig = data;
      this.prices = new Array(this.intconfig.length);

      this.intconfig.forEach( (value, index) =>
      {
        this.prices[index] = 0;
      })
    });
  }
  //total:number = parseInt(localStorage.getItem('baseprice'));
  getAltDesp( confid : string)
  {
    this.vehicle.getAltDespByConfId(confid).subscribe( (data) => this.alt = data);
  }

  managePrice(price,a,i)
  {
    this.prices[i] = price.target.value;
    this.recalculateTotalPrice();
    //localStorage.setItem('itotal',this.total.toString());
    localStorage.setItem('itotal',this.total.toString());
    localStorage.setItem('temp',this.total.toString());
  }

  recalculateTotalPrice()
  {
    this.total = parseInt((localStorage.getItem('stotal')));
  //  this.intTotal = parseInt((localStorage.getItem('stotal')));
    this.prices.forEach( (value, index) => {
      console.log( typeof value);
      let temp= +value;
      console.log( typeof temp);
      //this.total = this.total+temp;
      this.total = this.total+temp;
    })
  }

  invoice()
  {
      this.router.navigate(['/invoice']);
  }

}
