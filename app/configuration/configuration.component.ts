import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../vehicle.service';
import { IConfiguration } from '../IConfiguration';
import { IAlternate } from '../IAlternate';
import { IVariant } from '../IVariant';
import { element } from '@angular/core/src/render3';
import { Router } from '@angular/router';
import { MaxLengthValidator } from '@angular/forms';

@Component({
  selector: 'app-configuration',
  templateUrl: './configuration.component.html',
  styleUrls: ['./configuration.component.css']
})
export class ConfigurationComponent implements OnInit {

  constructor( private vehicle: VehicleService,private router:Router) { }

  default : IConfiguration[];
  stdconfig : IConfiguration[];
  alt : IAlternate[];
  varList : IVariant[];
  varid : string=null;
  order=new Array();
  newAlt : IAlternate[][];
  prices:number[];

  bprice : number;
  itotal : number;
  stotal : number;
  etotal : number;
  total : number;

  ngOnInit() {

    if (localStorage.getItem('varid')===null)
    {
      this.varid = null;
    }
    else
    {
      this.varid = JSON.parse(localStorage.getItem('varid'));
    }
//--------------
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
    this.total = parseInt((localStorage.getItem('baseprice')));
    //this.total = Math.max(this.bprice,this.stotal,this.itotal,this.etotal);
    console.log(this.total);
  //---------------- 
    this.vehicle.getDefaultFeatureByVarId(this.varid).subscribe( (data) => this.default = data);

    this.vehicle.getVariantByVarId( this.varid ).subscribe( (data) => this.varList = data);

    this.vehicle.getStandardConfigurableByVarId( this.varid ).subscribe( (data) => {
      this.stdconfig = data;
      this.prices = new Array(this.stdconfig.length);
      this.newAlt = new Array(this.stdconfig.length);
      this.stdconfig.forEach( (value, index) =>
      {
        this.vehicle.getAltDespByConfId(this.stdconfig[index].conf_id.toString()).subscribe( 
          (data) => {this.newAlt[index] = data; console.log(index, data)});
        this.prices[index] = 0;
      })
    });

    console.log(this.bprice);
    console.log(this.stotal);
    console.log(this.itotal);
    console.log(this.etotal);
  }
  

  getAltDesp( confid : string)
  {
    this.vehicle.getAltDespByConfId(confid).subscribe( (data) => this.alt = data);
  }
  id:number=0;
  //total:number = parseInt(localStorage.getItem('baseprice'));
  //total : number = +Math.max(this.bprice,this.stotal,this.itotal,this.etotal);

  managePrice(a_Id, index)
  {
    let temp:IAlternate = this.newAlt[index].find( function(element:IAlternate) { return element.alt_id == a_Id.target.value} );

    console.log(index, temp.alt_price);

    this.prices[index] = temp.alt_price;

    this.recalculateTotalPrice();
    //
    localStorage.setItem('stotal',this.total.toString());
    localStorage.setItem('temp',this.total.toString());
  }

  recalculateTotalPrice()
  {
    this.total = parseInt((localStorage.getItem('baseprice')));
    this.prices.forEach( (value, index) => {
      console.log( typeof value);
      let temp= +value;
      console.log( typeof temp);
      this.total = this.total+temp;
    })
  }

  invoice()
  {
      this.router.navigate(['/invoice'],{ state : {altid : this.order}});
  }
  selected(event,altid)
  {
    console.log(altid);
  }
  

}
