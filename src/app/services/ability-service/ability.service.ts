import { Injectable, ErrorHandler } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Hero } from '../../models/hero';
import { MessageService } from '../message-service/message.service';
import { ErrorHandlerHelper } from '../../Helpers/error-handler-helper';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AbilityService {

  private heroesUrl = 'api/hero';  // URL to web api
  private errorHandler: ErrorHandlerHelper = new ErrorHandlerHelper();

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET hero by id. Will 404 if id not found */
  getHero(id: number): Observable<Hero> {
    const url = `${this.heroesUrl}/${id}`;
    return this.http.get<Hero>(url).pipe(
      tap(_ => this.errorHandler.log(`fetched hero id=${id}`)),
      catchError(this.errorHandler.handleError<Hero>(`getHero id=${id}`))
    );
  }

  /* GET heroes whose name contains search term */
  searchAbilities(hero: Hero | number, term: string): Observable<Hero[]> {
    let id = typeof hero === 'number' ? hero : hero.id; 
    if (!term.trim()) {
      // if not search term, return empty hero array.
      return of([]);
    }
    return this.http.get<Hero[]>(`${this.heroesUrl}/${id}/?name=${term}`).pipe(
      tap(_ => this.errorHandler.log(`found heroes abilities matching "${term}"`)),
      catchError(this.errorHandler.handleError<Hero[]>('searchAbilities', []))
    );
  }

  //////// Save methods //////////

  /** POST: add a new hero to the server */
  addAbility (hero: Hero): Observable<Hero> {
    return this.http.post<Hero>(this.heroesUrl, hero, httpOptions).pipe(
      tap((newHero: Hero) => this.errorHandler.log(`added ability to hero w/ id=${newHero.id}`)),
      catchError(this.errorHandler.handleError<Hero>('addAbility'))
    );
  }

  /** DELETE: delete the hero from the server */
  deleteAbility (hero: Hero | number): Observable<Hero> {
    const id = typeof hero === 'number' ? hero : hero.id;
    const url = `${this.heroesUrl}/${id}`;

    return this.http.delete<Hero>(url, httpOptions).pipe(
      tap(_ => this.errorHandler.log(`deleted hero id=${id}`)),
      catchError(this.errorHandler.handleError<Hero>('deleteHero'))
    );
  }

  /** PUT: update the hero on the server */
  updateAbility (hero: Hero): Observable<any> {
    return this.http.put(this.heroesUrl, hero, httpOptions).pipe(
      tap(_ => this.errorHandler.log(`updated hero id=${hero.id}`)),
      catchError(this.errorHandler.handleError<any>('updateHero'))
    );
  }
}
