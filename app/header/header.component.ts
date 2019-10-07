import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  headerflag = false;
  constructor( private router : Router) { }

  ngOnInit() {
    if (localStorage.getItem('companyid') != null)
    {
      this.headerflag = true;
    }
  }

  logout()
  {
    localStorage.clear();
    this.router.navigateByUrl('/header', {skipLocationChange: true}).then(()=>
    this.router.navigate(["/home"])); 
  }

}
