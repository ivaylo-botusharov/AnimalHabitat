import { Component, ViewChild } from '@angular/core';
import notify from 'devextreme/ui/notify';
import { DxFormComponent } from 'devextreme-angular';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';

import { SpeciesDistributionService } from './species-distribution.service';
import { Ecoregion } from './ecoregion.model';

@Component({
  templateUrl: 'species-distribution-form.component.html',
  styleUrls: [ './species-distribution-form.component.scss' ]
})

export class SpeciesDistributionFormComponent {
  @ViewChild(DxFormComponent, { static: false }) form: DxFormComponent;
  colCountByScreen: object;
  speciesDataSource: DataSource;
  ecoregions: Ecoregion[] = [];

  private baseUrl = 'https://localhost:44360/';
  countriesUrl = this.baseUrl + 'api/' + 'country';
  ecoregionsUrl = this.baseUrl + 'api/' + 'ecoregion';
  ecoregionSelectBoxDisabled = true;

  constructor(private speciesDistributionService: SpeciesDistributionService) {
    this.colCountByScreen = {
      xs: 1,
      sm: 2,
      md: 3,
      lg: 4
    };

    this.speciesDataSource = new DataSource({
      store: new CustomStore({
          key: 'id',
          loadMode: 'raw',
          load: () => {
              return this.speciesDistributionService.getSpecies();
          }
      })
    });
  }

  buttonOptions: any = {
    text: 'Submit',
    type: 'success',
    useSubmitBehavior: true
  };

  onCountryValueChanged = (event: any) => {
    const countryId = event.value;
    this.speciesDistributionService.getEcoregions(countryId).then((ecoregions) => {
      this.ecoregions = ecoregions;
      this.ecoregionSelectBoxDisabled = false;
    });
  }

  onFormSubmit(e) {
    const formData = this.form.instance.option('formData');
    this.speciesDistributionService.addSpeciesDistribution(formData).then((result) => {
      notify({
        message: 'You have submitted the form',
        position: {
            my: 'center top',
            at: 'center top'
        }
      }, 'success', 3000);
    });

    e.preventDefault();
  }
}
