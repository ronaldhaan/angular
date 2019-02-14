import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

import { Ability } from '../../models/ability';
import { MessageService } from '../message-service/message.service';
import { ErrorHandlerHelper } from '../../Helpers/error-handler-helper';

import { Utilities } from 'src/app/utilities';

@Injectable({
  providedIn: 'root'
})
export class AbilityService {

  private abilitiesUrl = Utilities.apiServerUrl + '/api/abilities';  // URL to web api
  private errorHandler: ErrorHandlerHelper = new ErrorHandlerHelper();

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

    /** GET abilities from the server */
  getAbilities(): Observable<Ability[]> {
    return this.http.get<Ability[]>(this.abilitiesUrl)
      .pipe(
        tap(_ => this.errorHandler.log('fetched abilities')),
        catchError(this.errorHandler.handleError('getAbilities', []))
      );
  }

  /** GET ability by id. Will 404 if id not found */
  getAbility(id: string): Observable<Ability> {
    const url = `${this.abilitiesUrl}/${id}`;
    return this.http.get<Ability>(url).pipe(
      tap(_ => this.errorHandler.log(`fetched ability id=${id}`)),
      catchError(this.errorHandler.handleError<Ability>(`getAbility id=${id}`))
    );
  }

  /* GET abilities whose name contains search term */
  searchAbilities(ability: Ability | number, term: string): Observable<Ability[]> {
    const id = typeof ability === 'number' ? ability : ability.id;
    if (!term.trim()) {
      // if not search term, return empty ability array.
      return of([]);
    }
    return this.http.get<Ability[]>(`${this.abilitiesUrl}/${id}/?name=${term}`).pipe(
      tap(_ => this.errorHandler.log(`found abilities abilities matching "${term}"`)),
      catchError(this.errorHandler.handleError<Ability[]>('searchAbilities', []))
    );
  }

  //////// Save methods //////////

  /** POST: add a new ability to the server */
  addAbility (ability: Ability): Observable<Ability> {
    return this.http.post<Ability>(this.abilitiesUrl, ability, Utilities.httpOptions).pipe(
      tap((newAbility: Ability) => this.errorHandler.log(`added ability to ability w/ id=${newAbility.id}`)),
      catchError(this.errorHandler.handleError<Ability>('addAbility'))
    );
  }

  /** DELETE: delete the ability from the server */
  deleteAbility (ability: Ability | number): Observable<Ability> {
    const id = typeof ability === 'number' ? ability : ability.id;
    const url = `${this.abilitiesUrl}/${id}`;

    return this.http.delete<Ability>(url, Utilities.httpOptions).pipe(
      tap(_ => this.errorHandler.log(`deleted ability id=${id}`)),
      catchError(this.errorHandler.handleError<Ability>('deleteAbility'))
    );
  }

  /** PUT: update the ability on the server */
  updateAbility (ability: Ability): Observable<any> {
    const url = `${this.abilitiesUrl}/${ability.id}`;
    return this.http.put(url, ability, Utilities.httpOptions)
    .pipe(
      tap(_ => this.errorHandler.log(`updated ability id=${ability.id}`)),
      catchError(this.errorHandler.handleError<any>('updateAbility'))
    );
  }
}
