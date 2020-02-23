import { Component, ViewChild } from '@angular/core';
import notify from 'devextreme/ui/notify';
import { DxFormComponent } from 'devextreme-angular';

import { SpeciesDistributionService } from './species-distribution.service';
import { SpeciesDistributionPostModel } from './species-distribution-post-model';

@Component({
  templateUrl: 'species-distribution-form.component.html',
  styleUrls: [ './species-distribution-form.component.scss' ]
})

export class SpeciesDistributionFormComponent {
  @ViewChild(DxFormComponent, { static: false }) form: DxFormComponent;
  animals: any;
  colCountByScreen: object;

  constructor(private speciesDistributionService: SpeciesDistributionService) {
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
    this.speciesDistributionService.addAnimals(formData).subscribe(result => {
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
