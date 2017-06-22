import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { CounterComponent } from './components/counter/counter.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import {RouterModule, Routes} from "@angular/router";
import {ErrorComponent} from "./components/error/error.component";
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import {HttpModule} from "@angular/http";
import {FormsModule} from "@angular/forms";
import {VehicleService} from "./services/vehicle.service";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {ToasterModule} from "angular2-toaster";

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
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(routes),
    BrowserAnimationsModule,
    ToasterModule
  ],
  providers: [VehicleService],
  bootstrap: [AppComponent]
})

export class AppModule { }
