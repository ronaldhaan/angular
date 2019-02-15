import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
// components
import { Metahuman } from 'src/app/models/metahuman';
import { MetahumanService } from 'src/app/services/metahuman-service/metahuman.service';

@Component({
  selector: 'app-metahuman-search',
  templateUrl: './metahuman-search.component.html',
  styleUrls: [ './metahuman-search.component.css' ]
})
export class MetahumanSearchComponent implements OnInit {
  metas$: Observable<Metahuman[]>;
  private searchTerms = new Subject<string>();

  constructor(private metaService: MetahumanService) {}

  /**
   * Push a search term into the observable stream.
   * @param term The search term
   */
  search(term: string): void {
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    this.metas$ = this.searchTerms.pipe(
      // wait 300ms after each keystroke before considering the term
      debounceTime(300),

      // ignore new term if same as previous term
      distinctUntilChanged(),

      // switch to new search observable each time the term changes
      switchMap((term: string) => this.metaService.searchMetas('name', term)),
    );
  }
}
