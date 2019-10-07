import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../vehicle.service';
import { VariantData } from '../VariantData';
import { IConfiguration } from '../IConfiguration';
import { IVariant } from '../IVariant';
import { Router } from '@angular/router';

@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.css']
})
export class DefaultComponent implements OnInit {

  constructor( private vehicle:VehicleService, private router : Router) { }

  defaultFeatures : IConfiguration[];
  standardFeatures : IConfiguration[];
  interiorFeatures : IConfiguration[];
  exteriorFeatures : IConfiguration[];

  variantsList : IVariant[];

  varid : string;

  ngOnInit() {
    if (localStorage.getItem('varid')===null)
    {
      this.varid = null;
    }
    else
    {
      this.varid = JSON.parse(localStorage.getItem('varid'));
    }

    this.vehicle.getDefaultFeatureByVarId( this.varid ).subscribe( (data) => this.defaultFeatures = data);

    this.vehicle.getStandardFeatureByVarId( this.varid ).subscribe( (data) => this.standardFeatures = data);

    this.vehicle.getInteriorFeatureByVarId( this.varid ).subscribe( (data) => this.interiorFeatures = data);

    this.vehicle.getExteriorFeatureByVarId( this.varid ).subscribe( (data) => this.exteriorFeatures = data);

    this.vehicle.getVariantByVarId( this.varid ).subscribe( (data) => this.variantsList = data);
  }

  deleteStorage()
  {
    localStorage.removeItem('stotal');
    localStorage.removeItem('etotal');
    localStorage.removeItem('itotal');
    localStorage.setItem('temp',localStorage.getItem('baseprice'));
  }

  invoice()
  {
    localStorage.setItem('temp',localStorage.getItem('baseprice'));
      this.router.navigate(['/invoice']);
  }

}
