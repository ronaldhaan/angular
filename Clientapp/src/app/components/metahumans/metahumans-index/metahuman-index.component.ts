import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
// components
import { BaseComponent } from 'src/app/components/base-component/base.component';

import { Metahuman } from 'src/app/models/metahuman';
import { MetahumanService } from 'src/app/services/metahuman-service/metahuman.service';

@Component({
  selector: 'app-metahuman-index',
  templateUrl: './metahuman-index.component.html',
  styleUrls: ['./metahuman-index.component.css']
})
export class MetaHumanIndexComponent extends BaseComponent implements OnInit {
  public metahumans: Metahuman[];
  private metahumanService: MetahumanService;

  constructor(
    route: ActivatedRoute,
    metahumanService: MetahumanService,
    location: Location
  ) {
    super(route, location);
    this.metahumanService = metahumanService;
    this.metahumans = [];
  }


  ngOnInit() {
    this.getMetahumans();
  }
  /**
   * Gets the metahumans.
   */
  getMetahumans(): void {
    this.metahumanService.getHeroes()
    .subscribe(metahuman => this.metahumans = metahuman);
  }

  /**
   * Deletes a metahuman.
   * @param metahuman the metahuman that's about to be deleted
   */
  delete(metahuman: Metahuman): void {
    this.metahumans = this.metahumans.filter(h => h !== metahuman);
    this.metahumanService.deleteHero(metahuman).subscribe();
  }

}
