import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';

import { ErrorHandlerHelper } from 'src/app/Helpers/error-handler-helper';
import { MessageService } from '../message-service/message.service';

import { Utilities } from 'src/app/utilities';
import { Team } from 'src/app/models/team';
import { Observable } from 'rxjs';
import { Metahuman } from 'src/app/models/metahuman';
import { TeamMetahuman } from 'src/app/models/team-metahuman';

@Injectable({
  providedIn: 'root'
})
export class TeamMetahumanService {

  private teamMetaHumanUrl = Utilities.apiServerUrl + '/api/metahumansteams';  // URL to web api
  private errorHandler: ErrorHandlerHelper;

  constructor(private http: HttpClient) {
    this.errorHandler = new ErrorHandlerHelper();
  }

  //////// Save methods //////////

  /** POST: add a new team to the server */
  add (team: Team | string, meta: Metahuman | string): Observable<TeamMetahuman> {
    const metaTeam = this.getObject(team, meta);

    return this.http.post<TeamMetahuman>(this.teamMetaHumanUrl, metaTeam, Utilities.httpOptions).pipe(
        tap((newTeam: TeamMetahuman) => this.errorHandler.log(`added ability to ability w/ id=${newTeam.metahumanId}`)),
        catchError(this.errorHandler.handleError<TeamMetahuman>('addTeam'))
    );
  }

  /** DELETE: delete the ability from the server */
  remove(team: Team | string, meta: Metahuman | string): Observable<TeamMetahuman> {
    const metaTeam: TeamMetahuman = this.getObject(team, meta);
    const url = `${this.teamMetaHumanUrl}/delete`;

    return this.http.post<TeamMetahuman>(url, metaTeam, Utilities.httpOptions).pipe(
        tap(_ => this.errorHandler.log(`deleted link`)),
        catchError(this.errorHandler.handleError<TeamMetahuman>('deleteTeam'))
    );
  }

  getObject(team: Team | string, meta: Metahuman | string): TeamMetahuman {
    const metaId = typeof meta === 'string' ? meta : meta.id;
    const teamId = typeof team === 'string' ? team : team.id;

    return {
      metahumanId: metaId,
      teamId: teamId,
    };
  }
}
