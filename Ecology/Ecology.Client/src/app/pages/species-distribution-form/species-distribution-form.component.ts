import { Component, ViewChild } from '@angular/core';
import notify from 'devextreme/ui/notify';
import { DxFormComponent } from 'devextreme-angular';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { formatMessage } from 'devextreme/localization';

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
    text: this.submitButtonText,
    type: 'success',
    useSubmitBehavior: true
  };

  public get speciesDistributionTitle() {
    return formatMessage('speciesDistributionTitle', '');
  }

  public get formSubmissionSuccess() {
    return formatMessage('formSubmissionSuccess', '');
  }

  public get speciesInfoFieldset() {
    return formatMessage('speciesInfoFieldset', '');
  }

  public get biogeographyFieldSet() {
    return formatMessage('biogeographyFieldSet', '');
  }

  public get submitButtonText() {
    return formatMessage('submitButtonText', '');
  }

  public get speciesLabel() {
    return formatMessage('speciesLabel', '');
  }

  public get populationLabel() {
    return formatMessage('populationLabel', '');
  }

  public get countryLabel() {
    return formatMessage('countryLabel', '');
  }

  public get ecoregionLabel() {
    return formatMessage('ecoregionLabel', '');
  }

  public get speciesRequiredValidationMessage() {
    return formatMessage('speciesRequiredValidationMessage', '');
  }

  public get populationRequiredValidationMessage() {
    return formatMessage('populationRequiredValidationMessage', '');
  }

  public get populationPositiveNumberValidationMessage() {
    return formatMessage('populationPositiveNumberValidationMessage', '');
  }

  public get countryRequiredValidationMessage() {
    return formatMessage('countryRequiredValidationMessage', '');
  }

  public get ecoregionRequiredValidationMessage() {
    return formatMessage('ecoregionRequiredValidationMessage', '');
  }

  onCountryValueChanged = (event: any) => {
    const countryId = event.value;
    this.speciesDistributionService.getEcoregions(countryId).then((ecoregions) => {
      this.ecoregions = ecoregions;
      this.ecoregionSelectBoxDisabled = false;
      this.form.instance.option('formData').ecoregionId = undefined;
    });
  }

  onFormSubmit(e) {
    const formData = this.form.instance.option('formData');
    this.speciesDistributionService.addSpeciesDistribution(formData).then((result) => {
      notify({
        message: this.formSubmissionSuccess,
        position: {
            my: 'center top',
            at: 'center top'
        }
      }, 'success', 3000);
    });

    e.preventDefault();
  }
}
