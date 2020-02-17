import { Component, ViewChild } from '@angular/core';
import notify from 'devextreme/ui/notify';
import { DxFormComponent } from 'devextreme-angular';

import { AnimalsService } from './animals.service';
import { AnimalHabitat } from './animal-habitat';

@Component({
  templateUrl: 'animals.component.html',
  styleUrls: [ './animals.component.scss' ]
})

export class AnimalsComponent {
  @ViewChild(DxFormComponent, { static: false }) form:DxFormComponent;
  animals: any;
  colCountByScreen: object;

  constructor(private animalsService: AnimalsService) {
    this.colCountByScreen = {
      xs: 1,
      sm: 2,
      md: 3,
      lg: 4
    };
  }

  buttonOptions: any = {
    text: "Register",
    type: "success",
    useSubmitBehavior: true
  }

  onFormSubmit(e) {
    let formData = this.form.instance.option("formData");
    this.animalsService.addAnimals(formData).subscribe(result => {
      notify({
        message: "You have submitted the form",
        position: {
            my: "center top",
            at: "center top"
        }
      }, "success", 3000);
    });

    e.preventDefault();
  }
}
