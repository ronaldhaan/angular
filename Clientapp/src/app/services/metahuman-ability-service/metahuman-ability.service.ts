import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';

import { ErrorHandlerHelper } from 'src/app/Helpers/error-handler-helper';
import { MessageService } from '../message-service/message.service';

import { Utilities } from 'src/app/utilities';
import { Ability } from 'src/app/models/ability';
import { Observable } from 'rxjs';
import { Metahuman } from 'src/app/models/metahuman';
import { MetahumanAbility } from 'src/app/models/metahuman-ability';

@Injectable({
  providedIn: 'root'
})
export class MetahumanAbilityService {

  private metasAbilitiesUrl = Utilities.apiServerUrl + '/api/metahumansabilities';  // URL to web api
  private errorHandler: ErrorHandlerHelper;

  constructor(private http: HttpClient) {
    this.errorHandler = new ErrorHandlerHelper();
  }

  //////// Save methods //////////

  /** POST: add a new ability to the server */
  add (ability: Ability | string, meta: Metahuman | string): Observable<MetahumanAbility> {
    const metaAbility = this.getObject(ability, meta);

    return this.http.post<MetahumanAbility>(this.metasAbilitiesUrl, metaAbility, Utilities.httpOptions).pipe(
        tap((newAbility: MetahumanAbility) => this.errorHandler.log(`added ability to ability w/ id=${newAbility.metahumanId}`)),
        catchError(this.errorHandler.handleError<MetahumanAbility>('addAbility'))
    );
  }

  /** DELETE: delete the ability from the server */
  remove(ability: Ability | string, meta: Metahuman | string): Observable<MetahumanAbility> {
    const metaAbility: MetahumanAbility = this.getObject(ability, meta);
    const url = `${this.metasAbilitiesUrl}/delete`;

    return this.http.post<MetahumanAbility>(url, metaAbility, Utilities.httpOptions).pipe(
      tap(_ => this.errorHandler.log(`deleted link`)),
      catchError(this.errorHandler.handleError<MetahumanAbility>('deleteAbility'))
    );
  }

  getObject(ability: Ability | string, meta: Metahuman | string): MetahumanAbility {
    const metaId = typeof meta === 'string' ? meta : meta.id;
    const abilityId = typeof ability === 'string' ? ability : ability.id;

    return {
      metahumanId: metaId,
      abilityId,
    };
  }
}
