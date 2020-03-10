import { Injectable } from '@angular/core';
import { formatMessage } from 'devextreme/localization';

@Injectable({
  providedIn: 'root',
})
export class LocalizationMessageService {

    public get homeTitle() {
        return formatMessage('homeTitle', '');
    }

    public get speciesDistributionTitle() {
        return formatMessage('speciesDistributionTitle', '');
    }

    public get idColumnHeader() {
        return formatMessage('idColumnHeader', '');
    }

    public get speciesColumnHeader() {
        return formatMessage('speciesColumnHeader', '');
    }

    public get populationColumnHeader() {
        return formatMessage('populationColumnHeader', '');
    }

    public get countryColumnHeader() {
        return formatMessage('countryColumnHeader', '');
    }

    public get ecoregionColumnHeader() {
        return formatMessage('ecoregionColumnHeader', '');
    }

    public get biomeColumnHeader() {
        return formatMessage('biomeColumnHeader', '');
    }

    public get realmColumnHeader() {
        return formatMessage('realmColumnHeader', '');
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

    public get examplesTitle() {
        return formatMessage('examplesTitle', '');
    }

    public get createDistributionTitle() {
        return formatMessage('createDistributionTitle', '');
    }

    public get speciesDistributionMenuTitle() {
        return formatMessage('speciesDistributionMenuTitle', '');
    }

    public get chartsMenuTitle() {
        return formatMessage('chartsMenuTitle', '');
    }

    public get ecologyMenuTitle() {
        return formatMessage('ecologyMenuTitle', '');
    }

    public get homePageParagraphText() {
        return formatMessage('homePageParagraphText', '');
    }

    public get speciesByEcoregionTitle() {
        return formatMessage('speciesByEcoregionTitle', '');
    }
}
