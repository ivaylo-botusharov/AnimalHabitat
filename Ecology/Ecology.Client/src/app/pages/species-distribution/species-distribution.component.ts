import { Component } from '@angular/core';
import 'devextreme/data/odata/store';
import DataSource from 'devextreme/data/data_source';
import { LocalizationMessageService } from '../../localization-message.service';
import { SpeciesDistributionGetModel } from './species-distribution-get.model';

@Component({
  templateUrl: 'species-distribution.component.html'
})

export class SpeciesDistributionComponent {
  dataSource: DataSource;
  priority: any[];

  constructor(private messageService: LocalizationMessageService) {
    this.dataSource = new DataSource({
      store: {
        type: 'odata',
        version: 4,
        key: 'Id',
        url: 'https://localhost:44360/odata/speciesdistribution'
      }
    });

    this.dataSource.select((dataItem: SpeciesDistributionGetModel) => {
      return {
        Id: dataItem.Id,
        SpeciesCommonName: `${dataItem.SpeciesCommonName} (${dataItem.SpeciesScientificName})`,
        Population: dataItem.Population,
        Country: dataItem.Country,
        Ecoregion: dataItem.Ecoregion,
        Biome: dataItem.Biome,
        Realm: dataItem.Realm
      };
    });
  }

  // disables editing all columns except 'Population',
  // when creating entry allows all columns to be edited
  disableColumnsEditing(event: any) {
    if (event.parentType === 'filterRow' || (event.dataField === 'Population' && event.parentType === 'dataRow')) {
      return;
    }
    if (event.row === undefined || event.row.isNewRow === undefined || !event.row.isNewRow) {
      event.editorOptions.disabled = true;
    }
  }
}
