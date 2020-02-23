import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { SpeciesDistributionPostModel } from './species-distribution-post-model';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
    providedIn: 'root'
})
export class SpeciesDistributionService {

  private baseUrl = 'https://localhost:44360/'
  private speciesDistributionUrl = this.baseUrl + 'api/' + 'speciesdistribution';

  constructor(private http: HttpClient) {
  }

  addAnimals (speciesDistribution: SpeciesDistributionPostModel): Observable<SpeciesDistributionPostModel> {
    return this.http.post<SpeciesDistributionPostModel>(this.speciesDistributionUrl, speciesDistribution, httpOptions)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    return throwError(
      'Something bad happened; please try again later.');
  };
}
