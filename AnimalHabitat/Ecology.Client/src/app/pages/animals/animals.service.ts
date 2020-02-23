import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import { AnimalHabitat } from './animal-habitat';
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
export class AnimalsService {

  private baseUrl = 'https://localhost:44360/'
  private animalsUrl = this.baseUrl + 'api/' + 'animals';

  constructor(private http: HttpClient) {
  }

  addAnimals (animalHabitat: AnimalHabitat): Observable<AnimalHabitat> {
    return this.http.post<AnimalHabitat>(this.animalsUrl, animalHabitat, httpOptions)
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
