import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})


export class NavMenuComponent  implements OnInit,OnDestroy{
  fillerNav:string[]=[];
  ngOnInit(): void {
    console.log( this.mobileQuery);
  }

  // isExpanded = false;

  // collapse() {
  //   this.isExpanded = false;
  // }

  // toggle() {
  //   this.isExpanded = !this.isExpanded;
  // }


  mobileQuery: MediaQueryList;


  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
    this.mobileQuery = media.matchMedia('(max-width: 400px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addEventListener("change",this._mobileQueryListener);
    this.fillerNav = [
      'members',
      'meals',
      "expences",
      "reports"
    ];
  }
 

  ngOnDestroy(): void {
    this.mobileQuery.removeEventListener("change",this._mobileQueryListener);
  }


}




