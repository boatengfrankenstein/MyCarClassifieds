import { Component, OnInit } from '@angular/core';
import {VehicleService} from "../../services/vehicle.service";
import {Toast, ToasterConfig, ToasterService} from "angular2-toaster";

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  features: any[];
  vehicle = {MakeId: '',ModelId: '', IsRegistered: false, Features: [],
    ContactName: '',ContactPhone: '', ContactEmail: ''};
  toastConfig: ToasterConfig = new ToasterConfig({animation: 'fade',positionClass: 'toast-top-center'});
  constructor(private vehicleService: VehicleService,private toaster: ToasterService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes=>{
      this.makes = makes;
      console.log(this.makes);
    });

    this.vehicleService.getFeatures().subscribe(features=>{
      this.features = features;
      console.log(this.features);
    })
  }

  onMakeChange(){
    let selectedMake = this.makes.find(m=>m.Id == this.vehicle.MakeId);
    this.models = selectedMake ? selectedMake.Models : [];
    delete this.vehicle.ModelId
  }

  onFeatureToggle(id,event){
    if(event.target.checked){
      this.vehicle.Features.push(id);
    }else{
      let index = this.vehicle.Features.indexOf(id);
      this.vehicle.Features.splice(index,1);
    }
  }

  submit(f: HTMLFormElement){
    this.vehicleService.postNewVehicle(this.vehicle).subscribe(res => {
      console.log('Success');
      this.toaster.pop('success',"Success","The new vehicle has been inserted successfully");
      f.reset();
    },err => {
      console.log('Error');

      this.toaster.pop('error',"Error","There was an error inserting new vehicle.");
    });

  }
}
