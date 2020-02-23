import { Component } from '@angular/core';
import 'devextreme/data/odata/store';

@Component({
  templateUrl: 'display-data.component.html'
})

export class DisplayDataComponent {
  dataSource: any;
  priority: any[];

  constructor() {
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
}
