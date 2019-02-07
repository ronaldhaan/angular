import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

import { Hero } from 'src/app/models/hero';
import { HeroService } from 'src/app/services/hero-service/hero.service';
import { BaseComponent } from '../../base-component/base.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hero-create',
  templateUrl: './hero-create.component.html',
  styleUrls: ['./hero-create.component.css']
})
export class HeroCreateComponent extends BaseComponent implements OnInit {
  heroes: Hero[];
  private heroService: HeroService

  constructor(heroService: HeroService,
    route: ActivatedRoute,
    location: Location) 
  { 
    super(route, location);
    this.heroService = heroService;
  }

  ngOnInit() {
  }

  /**
   * Creates a new Hero.
   * @param name The name of the new Hero.
   */
  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.heroService.addHero({ name } as Hero)
      .subscribe(hero => {
        console.log(hero);
        this.heroes.push(hero);
        this.goBack();
      });
  }

}
