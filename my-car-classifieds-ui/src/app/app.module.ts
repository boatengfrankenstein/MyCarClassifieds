import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { CounterComponent } from './components/counter/counter.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import {Routes} from "@angular/router";
import {ErrorComponent} from "./components/error/error.component";
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';

const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: 'vehicles/new', component: VehicleFormComponent},
  {path: 'counter', component: CounterComponent},
  {path: 'fetch-data', component: FetchDataComponent},
  {path: '**',component: ErrorComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    VehicleFormComponent,
    CounterComponent,
    NavMenuComponent,
    HomeComponent,
    ErrorComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
