import { Component, OnInit } from '@angular/core';
import { SpeciesDistributionService } from './species-distribution.service';

@Component({
  selector: 'app-create-distribution',
  templateUrl: './create-distribution.component.html',
  styleUrls: ['./create-distribution.component.css']
})
export class CreateDistributionComponent implements OnInit {

  public selectedSpecies: string;

  public speciesList;

  constructor(private speciesDistributionService: SpeciesDistributionService) {
  }

  ngOnInit() {
    this.getSpecies();
  }

  getSpecies() {
    this.speciesDistributionService.getSpecies().subscribe(speciesList => {
      this.speciesList = speciesList;
    })
  }
}
