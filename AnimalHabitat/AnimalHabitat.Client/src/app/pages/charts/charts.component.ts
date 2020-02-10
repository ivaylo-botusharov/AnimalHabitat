import { Component, OnInit } from '@angular/core';
import { ChartsService, CitiesPopulation, ComplaintsWithPercent } from './charts.service';

@Component({
  selector: 'app-charts',
  templateUrl: './charts.component.html',
  styleUrls: ['./charts.component.scss'],
  providers: [ChartsService]
})
export class ChartsComponent implements OnInit {
  citiesPopulations: CitiesPopulation[];
  complaintsWithPercent: ComplaintsWithPercent[];

  constructor(chartsService: ChartsService) { 
    this.citiesPopulations = chartsService.getCitiesPopulations();
    this.complaintsWithPercent = chartsService.getComplaintsData();
  }

  ngOnInit() {
  }

  customizeTreeMapTooltip(arg) {
    var data = arg.node.data,
        result = null;

    if (arg.node.isLeaf()) {
      result = "<span class='city'>" + data.name + "</span> (" +
        data.country + ")<br/>Population: " + arg.valueText;
    }

    return {
        text: result
    };
  }

  customizeChartTooltip = (info: any) => {
    return {
      html: "<div><div class='tooltip-header'>" +
        info.argumentText + "</div>" +
        "<div class='tooltip-body'><div class='series-name'>" +
        info.points[0].seriesName +
        ": </div><div class='value-text'>" +
        info.points[0].valueText +
        "</div><div class='series-name'>" +
        info.points[1].seriesName +
        ": </div><div class='value-text'>" +
        info.points[1].valueText +
        "% </div></div></div>"
    };
  }
}
