import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  public showItems: boolean = false;
  public isAdmin: boolean = false;
  public isLogin: boolean = false;

  constructor(){}

  ngOnInit(): void {
  }
 
}
