import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
// components
import { Hero }         from '../../models/hero';
import { HeroService }  from '../../services/hero-service/hero.service';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: [ './hero-detail.component.css' ]
})
export class HeroDetailComponent implements OnInit {
  @Input() hero: Hero;
  heroes: Hero[];

  constructor(
    private route: ActivatedRoute,
    private heroService: HeroService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getHero();
  }

  /**
   * Gets the hero from the url.
   */
  getHero(): void {
    const id = this.route.snapshot.paramMap.get('id');
    
    this.heroService.getHero(id)
      .subscribe(hero => this.hero = hero);
  }

  /**
   * Gets all heroes.
   */
  getHeroes(): void {
    this.heroService.getHeroes()
    .subscribe(heroes => this.heroes = heroes);
  }

  /** 
   * Redirects back to the previous page.
   */
  goBack(): void {
    this.location.back();
  }

  /**
   * Adds a hero
   * @param name The name of the new hero.
   */
  add(name: string): void {
    name = name.trim();
    if (!name) { return; }

    this.heroService.addHero({ name } as Hero)
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }

  /**
   * Deletes a specific hero.
   * @param hero The hero that's about to be deleted
   */
  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroService.deleteHero(hero).subscribe();
  }

  /**
   * Updates a hero.
   */
 save(): void {
    this.heroService.updateHero(this.hero)
      .subscribe(() => this.goBack());
  }
}