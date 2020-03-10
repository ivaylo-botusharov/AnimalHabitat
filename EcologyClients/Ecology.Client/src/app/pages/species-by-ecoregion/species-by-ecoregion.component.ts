import { Component, OnInit } from '@angular/core';
import { LocalizationMessageService } from '../../localization-message.service';

@Component({
  selector: 'app-species-by-ecoregion',
  templateUrl: './species-by-ecoregion.component.html',
  styleUrls: ['./species-by-ecoregion.component.scss']
})
export class SpeciesByEcoregionComponent implements OnInit {

  speciesByEcoregionList = [
    {
      EcoregionId: 2,
      EcoregionName: 'First Ecoregion',
      Species: 'White Hourse'
    }
  ];
  constructor(private messageService: LocalizationMessageService) { }

  ngOnInit() {
  }
}
