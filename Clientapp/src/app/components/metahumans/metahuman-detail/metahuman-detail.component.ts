import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
// components
import { Metahuman } from 'src/app/models/metahuman';
import { MetahumanService } from 'src/app/services/metahuman-service/metahuman.service';
import { BaseComponent } from 'src/app/components/base-component/base.component';
import {Ability} from 'src/app/models/ability';
import {MetahumanAbilityService} from 'src/app/services/metahuman-ability-service/metahuman-ability.service';

@Component({
  selector: 'app-metahuman-detail',
  templateUrl: './metahuman-detail.component.html',
  styleUrls: [ './metahuman-detail.component.css' ]
})
export class MetahumanDetailComponent extends BaseComponent implements OnInit {
  @Input() public hero: Metahuman;
  private heroService: MetahumanService;
  private heroAbilityService: MetahumanAbilityService;

  constructor(
    route: ActivatedRoute,
    location: Location,
    heroService: MetahumanService,
    haService: MetahumanAbilityService
  ) {
    super(route, location);
    this.heroService = heroService;
    this.heroAbilityService = haService;
    this.hero = Metahuman.Empty();
  }

  ngOnInit(): void {
    this.getHero();
  }

  /**
   * Gets the hero from the url.
   */
  getHero(): void {
    const id = this.getParam('id');

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

  remove(ability: Ability): void {
    this.heroAbilityService.remove(ability, this.getParam('id')).subscribe(ability =>
    this.getHero());
  }
}
