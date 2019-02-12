import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base-component/base.component';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { AbilityService } from 'src/app/services/ability-service/ability.service';
import { Metahuman } from 'src/app/models/metahuman';
import { Ability } from 'src/app/models/ability';
import { MetahumanService } from 'src/app/services/metahuman-service/metahuman.service';
import { MetahumanAbilityService } from 'src/app/services/metahuman-ability-service/metahuman-ability.service';

@Component({
  selector: 'app-hero-ability-add',
  templateUrl: './metahuman-ability-add.component.html',
  styleUrls: ['./metahuman-ability-add.component.css']
})
export class MetahumanAbilityAddComponent extends BaseComponent implements OnInit {

  public abilityService: AbilityService;
  public heroService: MetahumanService;
  public heroAbilityService: MetahumanAbilityService;

  public chosenAbilities: Ability[];

  public hero: Metahuman;
  public abilities: Ability[];

  constructor(
    route: ActivatedRoute,
    location: Location,
    abilityService: AbilityService,
    heroService: MetahumanService,
    haService: MetahumanAbilityService
  ) {
    super(route, location);
    this.abilityService = abilityService;
    this.heroService = heroService;
    this.heroAbilityService = haService;

    this.hero = Metahuman.Empty();
    this.abilities = [];
    this.chosenAbilities = [];
   }

  ngOnInit() {
    this.getHero();
    this.getAbilities();

    console.log('hero', this.hero, 'abilities', this.abilities);
  }

  push(ability: Ability): void {
    if (this.chosenAbilities.indexOf(ability) === -1) {
      this.chosenAbilities.push(ability);
    }
  }

  remove(ability: Ability): void {
    if (this.chosenAbilities.length === 1) {
      if (this.chosenAbilities[0].id === ability.id) {
        this.chosenAbilities = [];
      }
    }
    for ( let i = 0; i < this.chosenAbilities.length - 1; i++) {
      if ( this.chosenAbilities[i].id === ability.id) {
        this.chosenAbilities.splice(i, 1);
      }
    }
  }

  getHero(): void {
    const id = this.getParam('id');
    this.heroService.getHero(id)
            .subscribe(hero => this.hero = hero);
  }

  getAbilities(): void {
    this.abilityService.getAbilities().subscribe(abilities => {
      if (this.hero.abilities.length > 0) {
        abilities.forEach(ability => {
          if (this.hero.abilities.indexOf(ability) === -1) {
            this.abilities.push(ability);
          }
        });
      } else {
        this.abilities = abilities;
      }
    });
  }

  add(): void {
    console.log('ca', this.chosenAbilities, 'a', this.abilities);

    if (this.chosenAbilities.length > 0) {
      console.log('true');
      const id = this.getParam('id');
      this.chosenAbilities
          .forEach(
              ability => this.heroAbilityService.add(ability, id).subscribe()
          );
      this.goBack();
    }
  }

}
