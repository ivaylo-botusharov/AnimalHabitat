import { Injectable } from '@angular/core';

export interface CityPopulation {
    value: number;
    name: string;
    country: string;
}

export interface CitiesPopulation {
    name: string;
    items: CityPopulation[];
}

let citiesPopulations: CitiesPopulation[] = [{
    name: "Africa",
    items: [{
        value: 21324000,
        name: "Lagos",
        country: "Nigeria"
    }, {
        value: 9735000,
        name: "Kinshasa",
        country: "Democratic Republic of the Congo"
    }, {
        value: 9278441,
        name: "Cairo",
        country: "Egypt"
    }]
}, {
    name: "Asia",
    items: [{
        value: 24256800,
        name: "Shanghai",
        country: "China"
    }, {
        value: 23500000,
        name: "Karachi",
        country: "Pakistan"
    }, {
        value: 21516000,
        name: "Beijing",
        country: "China"
    }, {
        value: 16787941,
        name: "Delhi",
        country: "India"
    }, {
        value: 15200000,
        name: "Tianjin",
        country: "China"
    }]
}, {
    name: "Australia",
    items: [{
        value: 4840600,
        name: "Sydney",
        country: "Austraila"
    }, {
        value: 4440000,
        name: "Melbourne",
        country: "Austraila"
    }]
}, {
    name: "Europe",
    items: [{
        value: 14160467,
        name: "Istanbul",
        country: "Turkey"
    }, {
        value: 12197596,
        name: "Moscow",
        country: "Russia"
    }, {
        value: 8538689,
        name: "London",
        country: "United Kingdom"
    }, {
        value: 5191690,
        name: "Saint Petersburg",
        country: "Russia"
    }, {
        value: 4470800,
        name: "Ankara",
        country: "Turkey"
    }, {
        value: 3517424,
        name: "Berlin",
        country: "Germany"
    }]
}, {
    name: "North America",
    items: [{
        value: 8874724,
        name: "Mexico City",
        country: "Mexico"
    }, {
        value: 8550405,
        name: "New York City",
        country: "United States"
    }, {
        value: 3884307,
        name: "Los Angeles",
        country: "United States"
    }, {
        value: 2808503,
        name: "Toronto",
        country: "Canada"
    }]
}, {
    name: "South America",
    items: [{
        value: 11895893,
        name: "São Paulo",
        country: "Brazil"
    }, {
        value: 8693387,
        name: "Lima",
        country: "Peru"
    }, {
        value: 7776845,
        name: "Bogotá",
        country: "Colombia"
    }, {
        value: 6429923,
        name: "Rio de Janeiro",
        country: "Brazil"
    }]
}];

class Complaints {
  complaint: string;
  count: number
}

export class ComplaintsWithPercent {
  complaint: string;
  count: number;
  cumulativePercent: number;
}

let complaintsData: Complaints[] = [
  { complaint: "Cold pizza", count: 780 },
  { complaint: "Not enough cheese", count: 120 },
  { complaint: "Underbaked or Overbaked", count: 52 },
  { complaint: "Delayed delivery", count: 1123 },
  { complaint: "Damaged pizza", count: 321 },
  { complaint: "Incorrect billing", count: 89 },
  { complaint: "Wrong size delivered", count: 222 }
];

@Injectable()
export class ChartsService {
  getCitiesPopulations() {
    return citiesPopulations;
  }

  getComplaintsData(): ComplaintsWithPercent[] {
    var data = complaintsData.sort(function (a, b) {
      return b.count - a.count;
    }),
    totalCount = data.reduce(function (prevValue, item) {
      return prevValue + item.count;
    }, 0),
    cumulativeCount = 0;
    
    return data.map(function (item, index) {
      cumulativeCount += item.count;
      return {
        complaint: item.complaint,
        count: item.count,
        cumulativePercent: Math.round(cumulativeCount * 100 / totalCount)
      };
    });
  }
}