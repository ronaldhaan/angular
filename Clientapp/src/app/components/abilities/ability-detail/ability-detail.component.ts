import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
//components
import { BaseComponent } from 'src/app/components/base-component/base.component';

import { Ability } from 'src/app/models/ability';
import { AbilityService } from 'src/app/services/ability-service/ability.service';

@Component({
  selector: 'app-ability-detail',
  templateUrl: './ability-detail.component.html',
  styleUrls: ['./ability-detail.component.css']
})
export class AbilityDetailComponent extends BaseComponent implements OnInit {
  @Input() public ability: Ability;

  private abilityService: AbilityService;

  constructor(
    route: ActivatedRoute,
    abilityService: AbilityService,
    location: Location
  ) {
    super(route, location); 
    this.abilityService = abilityService;
    this.ability = {
      id: '',
      name: '',
      description: '',
      heroes: []
    }
  }

  ngOnInit(): void {
    this.getAbility();
  }

  /**
   * Gets the ability from the url.
   */
  getAbility(): void {
    const id = this.getParam("id");
    console.log(id);
    this.abilityService.getAbility(id)
      .subscribe(ability => {
        console.log('1', ability);
        this.ability = ability;
      });

      console.log(this.ability);
  }

  /**
   * Updates a ability.
   */
  save(): void {
      this.abilityService.updateAbility(this.ability)
        .subscribe(() => this.goBack());
    }
}
