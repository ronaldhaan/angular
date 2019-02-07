import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
//components
import { BaseComponent } from 'src/app/components/base-component/base.component';

import { Hero } from 'src/app/models/hero';
import { HeroService } from 'src/app/services/hero-service/hero.service';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes-index.component.html',
  styleUrls: ['./heroes-index.component.css']
})
export class HeroesComponent extends BaseComponent implements OnInit {
  public heroes: Hero[];
  private heroService: HeroService;

  constructor(
    route: ActivatedRoute,
    heroService: HeroService,
    location: Location
  ) {
    super(route, location); 
    this.heroService = heroService;
  }


  ngOnInit() {
    this.getHeroes();
  }
  /**
   * Gets the heroes.
   */
  getHeroes(): void {
    this.heroService.getHeroes()
    .subscribe(heroes => this.heroes = heroes);
  }

  /**
   * Deletes a hero.
   * @param hero the hero that's about to be deleted
   */
  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroService.deleteHero(hero).subscribe();
  }

}