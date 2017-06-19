import { Component, OnInit } from '@angular/core';
import {VehicleService} from "../../services/vehicle.service";

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  features: any[];
  vehicle = {makeId: ''};
  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes=>{
      this.makes = makes;
    });

    this.vehicleService.getFeatures().subscribe(features=>{
      this.features = features;
    })
  }

  onMakeChange(){
    let selectedMake = this.makes.find(m=>m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }
}
