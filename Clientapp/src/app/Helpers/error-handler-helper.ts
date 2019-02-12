import { Observable, of } from 'rxjs';

import { MessageService } from '../services/message-service/message.service';

/** Helper to handle the errors. */
export class ErrorHandlerHelper {

    public className: string = '';

    public messageService: MessageService = new MessageService();

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - The name of the operation that failed
   * @param result - Optional value to return as the observable result
   */
  public handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /**
   * Logs a MetahumanService message with the MessageService
   * @param message The message to be logged.
   */
  public log(message: string): void {
    this.messageService.add(`${this.className}: ${message}`);
  }
}
