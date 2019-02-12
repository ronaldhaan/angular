import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { BaseComponent } from '../../base-component/base.component';

import { Ability } from 'src/app/models/ability';
import { AbilityService } from 'src/app/services/ability-service/ability.service';

@Component({
  selector: 'app-ability-create',
  templateUrl: './ability-create.component.html',
  styleUrls: ['./ability-create.component.css']
})
export class AbilityCreateComponent extends BaseComponent implements OnInit {
  public ability: Ability;
  private abilityService: AbilityService;

  constructor(
    abilityService: AbilityService,
    route: ActivatedRoute,
    location: Location) {
      super(route, location);
      this.abilityService = abilityService;
      this.ability = Ability.Empty();
     }

  ngOnInit() {

  }

  add(ability: Ability): void {
    console.log(ability);
    ability.name = ability.name.trim();
    ability.description = ability.description.trim();

    if (!ability.name) { return; }

    this.abilityService.addAbility(ability)
      .subscribe((ability) => {
        console.log('done', ability);
        this.goBack();
      });
  }
}
