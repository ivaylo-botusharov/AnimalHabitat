import { Component } from '@angular/core';
import 'devextreme/data/odata/store';
import { formatMessage } from 'devextreme/localization';
import { LocalizationMessageService } from '../../localization-message.service';

@Component({
  templateUrl: 'species-distribution.component.html'
})

export class SpeciesDistributionComponent {
  dataSource: any;
  priority: any[];

  constructor(private messageService: LocalizationMessageService) {
    this.dataSource = {
      store: {
        type: 'odata',
        version: 4,
        key: 'Id',
        url: 'https://localhost:44360/odata/speciesdistribution'
      },
      select: [
        'Id',
        'Species',
        'Population',
        'Country',
        'Ecoregion',
        'Biome',
        'Realm'
      ]
    };
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
