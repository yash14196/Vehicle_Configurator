import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SegmentData } from '../SegmentData';
import { ManufacturerData } from '../ManufacturerData';
import { VariantData } from '../VariantData';
import { Observable } from 'rxjs';
import { ISegment } from '../ISegment';
import { IManufacturer } from '../IManufacturer';
import { IVariant } from '../IVariant';
import { VehicleService } from '../vehicle.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

   private segments : ISegment[];
   private manufacturers : IManufacturer[];
   private variants : IVariant[]; 

   flag = false;
   //islogged = false;
   segid : number;
   manid: number;
   usrid : string;
  constructor( private router:Router, private vehicle : VehicleService) { 
    //this.usrid = this.router.getCurrentNavigation().extras.state.uid;
  }

  seg : SegmentData = new SegmentData(0,null);

    getAllSeg()
    {
       this.vehicle.getAllSegment().subscribe( (data) => this.segments = data);
    }
  man : ManufacturerData = new ManufacturerData(0,null);

  va : VariantData = new VariantData(0,null,0,0,15,0,null);
  ngOnInit() {
    this.getAllSeg();

    if (localStorage.getItem('companyid')===null)
    {
      this.usrid = null;
    }
    else
    {
      this.usrid = JSON.parse(localStorage.getItem('companyid'));
      console.log(this.usrid);
    }
  }

  onChangeSegment(event)
  {
    this.segid = event.target.value;
    this.vehicle.getManufacturerBySegId(this.segid).subscribe ( (data) => this.manufacturers = data);
  }

  onChangeManufacturers(event)
  {
    
    this.manid=event.target.value;
    console.log(this.manid);
    this.vehicle.getVariantBySegIdnManId(this.manid).subscribe( (data) => this.variants = data);
  }

  sendVarid(event,v)
  {
    console.log(event.target.value);

    v.forEach(element => {

      console.log(element.base_price);
      localStorage.setItem('baseprice',JSON.stringify(element.base_price));  
    });
    localStorage.setItem('varid',JSON.stringify(event.target.value));
    this.flag = true;
  }

  nextPage()
  {
  
    this.router.navigate(['/default']);
  }

  /*
  chkLogin()
  {
    this.islogged = true;
    this.vehicle.userlogindone(this.islogged);
  } 
  */   
} 

