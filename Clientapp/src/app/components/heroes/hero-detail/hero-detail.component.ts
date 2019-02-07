import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
// components
import { Hero }         from 'src/app/models/hero';
import { HeroService }  from 'src/app/services/hero-service/hero.service';
import { BaseComponent } from 'src/app/components/base-component/base.component';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: [ './hero-detail.component.css' ]
})
export class HeroDetailComponent extends BaseComponent implements OnInit {
  @Input() public hero: Hero;
  private heroService: HeroService;

  constructor(
    route: ActivatedRoute,
    heroService: HeroService,
    location: Location
  ) {
    super(route, location); 
    this.heroService = heroService;
    this.hero = {
      id: 0,
      name: '',
      abilities: [],
    }
  }

  ngOnInit(): void {
    this.getHero();
  }

  /**
   * Gets the hero from the url.
   */
  getHero(): void {
    const id = this.getParam("id");
    
    this.heroService.getHero(id)
      .subscribe(hero => this.hero = hero);
  }

  /**
   * Updates a hero.
   */
 save(): void {
    this.heroService.updateHero(this.hero)
      .subscribe(() => this.goBack());
  }
}