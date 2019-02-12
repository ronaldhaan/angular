import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Ability } from 'src/app/models/ability';
import { AbilityService } from 'src/app/services/ability-service/ability.service';
import { BaseComponent } from '../../base-component/base.component';

@Component({
  selector: 'app-abilities-index',
  templateUrl: './abilities-index.component.html',
  styleUrls: ['./abilities-index.component.css']
})
export class AbilitiesIndexComponent extends BaseComponent implements OnInit {
  public abilities: Ability[];
  private abilityService: AbilityService;

  constructor(
    route: ActivatedRoute,
    abilityService: AbilityService,
    location: Location
  ) {
    super(route, location);
    this.abilityService = abilityService;
  }


  ngOnInit() {
    this.getAbilities();
  }

  /**
   * Gets the abilities.
   */
  getAbilities(): void {
    this.abilityService.getAbilities()
      .subscribe(abilities => this.abilities = abilities);

    console.log(this.abilities);
  }

  /**
   * Deletes a ability.
   * @param ability the ability that's about to be deleted
   */
  delete(ability: Ability): void {
    this.abilityService.deleteAbility(ability)
        .subscribe( () => this.abilities = this.abilities.filter(h => h !== ability));
  }
}
