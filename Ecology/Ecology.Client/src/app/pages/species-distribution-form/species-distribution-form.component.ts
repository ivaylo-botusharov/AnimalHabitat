import { Component, ViewChild } from '@angular/core';
import notify from 'devextreme/ui/notify';
import { DxFormComponent } from 'devextreme-angular';
import ArrayStore from "devextreme/data/array_store";
import DataSource from "devextreme/data/data_source";

import { SpeciesDistributionService } from './species-distribution.service';
import { SpeciesDistributionPostModel } from './species-distribution-post-model';

@Component({
  templateUrl: 'species-distribution-form.component.html',
  styleUrls: [ './species-distribution-form.component.scss' ]
})

export class SpeciesDistributionFormComponent {
  @ViewChild(DxFormComponent, { static: false }) form: DxFormComponent;
  colCountByScreen: object;

  selectedSpecies: any;
  speciesDataSource: DataSource;
  speciesArr = [
    { id: 1, name: "Monkey" },
    { id: 2, name: "Hourse" },
    { id: 3, name: "Elephant" }
  ];

  constructor(private speciesDistributionService: SpeciesDistributionService) {
    this.colCountByScreen = {
      xs: 1,
      sm: 2,
      md: 3,
      lg: 4
    };

    this.speciesDataSource = new DataSource({
      store: new ArrayStore({
          key: "id",
          data: this.speciesArr,
      }),
    });
  }

  buttonOptions: any = {
    text: "Submit",
    type: "success",
    useSubmitBehavior: true
  }

  onSpeciesSelectionChange(e) {
    console.log('species selection has changed...');
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
