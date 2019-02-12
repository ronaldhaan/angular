import { Injectable, ErrorHandler } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
//components
import { Metahuman } from '../../models/metahuman';
import { MessageService } from '../message-service/message.service';
import { ErrorHandlerHelper } from '../../Helpers/error-handler-helper';

import { UTILITIES } from 'src/app/utilities';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class MetahumanService {

  private heroesUrl = UTILITIES.apiServerUrl + '/api/metahumans';  // URL to web api
  private errorHandler: ErrorHandlerHelper = new ErrorHandlerHelper();

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET metahumans from the server */
  getHeroes (): Observable<Metahuman[]> {
    return this.http.get<Metahuman[]>(this.heroesUrl)
      .pipe(
        tap(_ => this.errorHandler.log('fetched metahumans')),
        catchError(this.errorHandler.handleError('getHeroes', []))
      );
  }

  /**
   * GETs `Metahuman` by id. Return `undefined` when id not found
   * @param id The id of the `Metahuman`.
   */
  getHeroNo404<Data>(id: number): Observable<Metahuman> {
    const url = `${this.heroesUrl}/${id}`;
    return this.http.get<Metahuman[]>(url)
      .pipe(
        map(heroes => heroes[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.errorHandler.log(`${outcome} hero id=${id}`);
        }),
        catchError(this.errorHandler.handleError<Metahuman>(`getHero id=${id}`))
      );
  }

  /**
   *  GET `Metahuman` by id. Will `404` if id not found
   * @param id The id of the `Metahuman`
   */
  getHero(id: string): Observable<Metahuman> {
    const url = `${this.heroesUrl}/${id}`;
    return this.http.get<Metahuman>(url)
      .pipe(
        tap(_ => this.errorHandler.log(`fetched hero id=${id}`)),
        catchError(this.errorHandler.handleError<Metahuman>(`getHero id=${id}`))
      );
  }
 
  /**
   * Gets all Heroes whose `name` contains search term 
   * @param term The search term.
   */
  searchHeroes(term: string): Observable<Metahuman[]> {
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return of([]);
    }
    return this.http.get<Metahuman[]>(`${this.heroesUrl}/?name=${term}`)
      .pipe(
        tap(_ => this.errorHandler.log(`found heroes matching "${term}"`)),
        catchError(this.errorHandler.handleError<Metahuman[]>('searchHeroes', []))
      );
  }

  //////// Save methods //////////

  /**
   * `POST`: add a new `Metahuman` to the server
   * @param hero The new `Metahuman` to create
   */
  addHero (hero: Metahuman): Observable<Metahuman> {
    return this.http.post<Metahuman>(this.heroesUrl, hero, httpOptions)
      .pipe(
        tap((newHero: Metahuman) => this.errorHandler.log(`added hero w/ id=${newHero.id}`)),
        catchError(this.errorHandler.handleError<Metahuman>('addHero'))
      );
  }

  /**
   * `DELETE`: delete the `Metahuman` from the server
   * @param hero The `Metahuman` to be deleted.
   */
  deleteHero (hero: Metahuman | number): Observable<Metahuman> {
    const id = typeof hero === 'number' ? hero : hero.id;
    const url = `${this.heroesUrl}/${id}`;

    return this.http.delete<Metahuman>(url, httpOptions)
      .pipe(
        tap(_ => this.errorHandler.log(`deleted hero id=${id}`)),
        catchError(this.errorHandler.handleError<Metahuman>('deleteHero'))
      );
  }

  /**
   * `PUT`: update the `Metahuman` on the server
   * @param hero The `Metahuman` to be updated
   */
  updateHero (hero: Metahuman): Observable<any> {
    const url = `${this.heroesUrl}/${hero.id}`;

    return this.http.put(url, hero, httpOptions)
      .pipe(
        tap(_ => this.errorHandler.log(`updated hero id=${hero.id}`)),
        catchError(this.errorHandler.handleError<any>('updateHero'))
      );
  }
}
