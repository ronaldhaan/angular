import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

import { Metahuman } from 'src/app/models/metahuman';
import { MetahumanService } from 'src/app/services/metahuman-service/metahuman.service';
import { BaseComponent } from '../../base-component/base.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-metahuman-create',
  templateUrl: './metahuman-create.component.html',
  styleUrls: ['./metahuman-create.component.css']
})
export class MetahumanCreateComponent extends BaseComponent implements OnInit {
  metahuman: Metahuman[];
  private MetahumanService: MetahumanService;

  constructor(heroService: MetahumanService,
    route: ActivatedRoute,
    location: Location) {
    super(route, location);
    this.MetahumanService = heroService;
    this.metahuman = [];
  }

  ngOnInit() {
  }

  /**
   * Creates a new Metahuman.
   * @param name The name of the new Metahuman.
   */
  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.MetahumanService.addHero({ name } as Metahuman)
      .subscribe(hero => {
        console.log(hero);
        this.metahuman.push(hero);
        this.goBack();
      });
  }

}
