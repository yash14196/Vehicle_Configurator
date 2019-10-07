import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../vehicle.service';
import { Router } from '@angular/router';
import { IConfiguration } from '../IConfiguration';
import { IAlternate } from '../IAlternate';
import { IVariant } from '../IVariant';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {
  userid;
  altid:any[]=[];
  default : IConfiguration[];
  stdconfig : IConfiguration[];
  alt : IAlternate[];
  varList : IVariant[];
  varid : string=null;
  altColl : any[] = [];
  baseprice : number;

  constructor(private vehicle:VehicleService,private router:Router) {

    //this.vehicle.getAltId().subscribe((data)=>console.log(data));

    //console.log(this.altid);

   }
  
  

  ngOnInit() {
    this.altid=this.vehicle.getaltdesp();
    //this.calculateTotal();
   // console.log(this.altid);
   if (localStorage.getItem('varid')===null)
   {
     this.varid = null;
   }
   else
   {
     this.varid = JSON.parse(localStorage.getItem('varid'));
   }

   if (localStorage.getItem('temp')===null)
   {
     this.baseprice = 0;
   }
   else
   {
     this.baseprice = parseInt(localStorage.getItem('temp'));
   }

   this.vehicle.getDefaultFeatureByVarId(this.varid).subscribe( (data) => this.default = data);

   this.vehicle.getVariantByVarId( this.varid ).subscribe( (data) => this.varList = data);

  //  for( let i = 0; i<this.altid.length; i++)
  //  {
  //   this.vehicle.getAltDespByAltId( this.altid[i] ).subscribe( (data) => {this.alt = data;
  //     this.altColl.push(this.alt);
  //     //console.log(this.altColl);
      
  //   });
  //  }
   
  }

  // calculateTotal()
  // {
  //   let stotal=parseInt(localStorage.getItem('stotal'))-parseInt(localStorage.getItem('baseprice'));
  //   let itotal=parseInt(localStorage.getItem('itotal'))-parseInt(localStorage.getItem('baseprice'));
  //   let etotal=parseInt(localStorage.getItem('etotal'))-parseInt(localStorage.getItem('baseprice'));

  //   this.baseprice=parseInt(localStorage.getItem('baseprice'))+stotal+itotal+etotal;

  // }

}
