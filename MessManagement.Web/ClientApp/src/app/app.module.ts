import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MemberLandingComponent } from './member-landing/member-landing.component';
import { MemberAddComponent } from './member-add/member-add.component';
import { MemberDetailsComponent } from './member-details/member-details.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MemberLandingComponent,
    MemberAddComponent,
    MemberDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      //{ path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'members', component: MemberLandingComponent },
      { path: 'members/add', component: MemberAddComponent },
      { path: 'members/details/:id', component: MemberDetailsComponent }


    ])
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
