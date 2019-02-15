import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable} from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
// components
import { Team } from '../../models/team';
import { MessageService } from '../message-service/message.service';
import { ErrorHandlerHelper } from '../../Helpers/error-handler-helper';

import { Utilities } from 'src/app/utilities';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  private readonly url = `${Utilities.apiServerUrl}/api/teams`;
  private errorHandler: ErrorHandlerHelper;
  private http: HttpClient;
  private messageService: MessageService;


  constructor(http: HttpClient, messageService: MessageService) {
    this.errorHandler = new ErrorHandlerHelper();
    this.http = http;
    this.messageService = messageService;
  }

  getAll(): Observable<Team[]> {
    return this.http.get<Team[]>(this.url)
        .pipe(
            tap(() => this.errorHandler.log('fetched teams')),
            catchError(this.errorHandler.handleError('getTeams', []))
        );
  }

  /**
   * `GET`: gets one team.
   * @param id id of the team.
   */
  getOne(id: string): Observable<Team> {
    const uri = `${this.url}/${id}`;
    return this.http.get<Team>(uri)
        .pipe(
          tap(() => this.errorHandler.log('fetched teams')),
          catchError(this.errorHandler.handleError<Team>('getTeams', {} as Team))
        );
  }

  /**
   * `POST`: add a new `Team` to the server
   * @param team The new `Team` to create
   */
  add(team: Team): Observable<Team> {
    return this.http.post<Team>(this.url, team, Utilities.httpOptions)
        .pipe(
            tap((newTeam: Team) => this.errorHandler.log(`added meta w/ id=${newTeam.id}`)),
            catchError(this.errorHandler.handleError<Team>('addMeta'))
        );
  }

  /**
   * `PUT`: update the `Team` on the server
   * @param meta The `Team` to be updated
   */
  update(meta: Team): Observable<any> {
    const url = `${this.url}/${meta.id}`;

    return this.http.put(url, meta, Utilities.httpOptions)
        .pipe(
            tap(_ => this.errorHandler.log(`updated team id=${meta.id}`)),
            catchError(this.errorHandler.handleError<any>('update Team'))
        );
  }

  /**
   * `DELETE`: delete the `Team` from the server
   * @param team The `Team` to be deleted.
   */
  delete (team: Team | string): Observable<Team> {
    const id = typeof team === 'string' ? team : team.id;
    const url = `${this.url}/${id}`;

    return this.http.delete<Team>(url, Utilities.httpOptions)
        .pipe(
            tap(_ => this.errorHandler.log(`deleted team id=${id}`)),
            catchError(this.errorHandler.handleError<Team>('deleteMeta'))
        );
  }
}
