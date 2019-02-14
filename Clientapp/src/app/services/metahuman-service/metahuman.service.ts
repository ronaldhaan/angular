import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
// components
import { Metahuman } from '../../models/metahuman';
import { ErrorHandlerHelper } from '../../Helpers/error-handler-helper';
import { MessageService } from '../message-service/message.service';

import { Utilities } from 'src/app/utilities';


@Injectable({ providedIn: 'root' })
export class MetahumanService {

  private metasUrl = Utilities.apiServerUrl + '/api/metahumans';  // URL to web api
  private errorHandler: ErrorHandlerHelper;
  private messageService: MessageService;
  private http: HttpClient

  constructor(http: HttpClient, messageService: MessageService) {
    this.http = http;
    this.errorHandler = new ErrorHandlerHelper();
    this.messageService = messageService;
  }

  /** GET metahumans from the server */
  getMetas (): Observable<Metahuman[]> {
    return this.http.get<Metahuman[]>(this.metasUrl)
      .pipe(
        tap( h => {
          const outcome = h ? 'fetched' : 'not found';
          this.messageService.add(`MetahumanService: ${outcome}`);
          this.errorHandler.log(`${outcome} fetched metahumans`);
        }),
        catchError(this.errorHandler.handleError('getMetas', []))
      );
  }

  /**
   *  GET `Metahuman` by id. Will `404` if id not found
   * @param id The id of the `Metahuman`
   */
  getMeta(id: string): Observable<Metahuman> {
    const url = `${this.metasUrl}/${id}`;
    return this.http.get<Metahuman>(url)
      .pipe(
        tap(_ => this.errorHandler.log(`fetched meta id=${id}`)),
        catchError(this.errorHandler.handleError<Metahuman>(`getMeta id=${id}`))
      );
  }

  /**
   * Gets all Metas whose `name` contains search term
   * @param term The search term.
   */
  searchMetas(term: string): Observable<Metahuman[]> {
    if (!term.trim()) {
      // if not search term, return empty meta array.
      return of([]);
    }
    return this.http.get<Metahuman[]>(`${this.metasUrl}/?name=${term}`)
      .pipe(
        tap(_ => this.errorHandler.log(`found metas matching "${term}"`)),
        catchError(this.errorHandler.handleError<Metahuman[]>('searchMetas', []))
      );
  }

  //////// Save methods //////////

  /**
   * `POST`: add a new `Metahuman` to the server
   * @param meta The new `Metahuman` to create
   */
  addMeta (meta: Metahuman): Observable<Metahuman> {
    return this.http.post<Metahuman>(this.metasUrl, meta, Utilities.httpOptions)
      .pipe(
        tap((newMeta: Metahuman) => this.errorHandler.log(`added meta w/ id=${newMeta.id}`)),
        catchError(this.errorHandler.handleError<Metahuman>('addMeta'))
      );
  }

  /**
   * `DELETE`: delete the `Metahuman` from the server
   * @param meta The `Metahuman` to be deleted.
   */
  deleteMeta (meta: Metahuman | number): Observable<Metahuman> {
    const id = typeof meta === 'number' ? meta : meta.id;
    const url = `${this.metasUrl}/${id}`;

    return this.http.delete<Metahuman>(url, Utilities.httpOptions)
        .pipe(
            tap(_ => this.errorHandler.log(`deleted meta id=${id}`)),
            catchError(this.errorHandler.handleError<Metahuman>('deleteMeta'))
        );
  }

  /**
   * `PUT`: update the `Metahuman` on the server
   * @param meta The `Metahuman` to be updated
   */
  updateMeta (meta: Metahuman): Observable<any> {
    const url = `${this.metasUrl}/${meta.id}`;

    return this.http.put(url, meta, Utilities.httpOptions)
      .pipe(
        tap(_ => this.errorHandler.log(`updated meta id=${meta.id}`)),
        catchError(this.errorHandler.handleError<any>('updateMeta'))
      );
  }
}
