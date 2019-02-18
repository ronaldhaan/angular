import {Component, Input, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { BaseComponent } from '../../base-component/base.component';

import { Ability } from 'src/app/models/ability';
import { AbilityService } from 'src/app/services/ability-service/ability.service';
import {MessageService} from '../../../services/message-service/message.service';

@Component({
  selector: 'app-ability-create',
  templateUrl: './ability-create.component.html',
  styleUrls: ['./ability-create.component.css']
})
export class AbilityCreateComponent extends BaseComponent implements OnInit {
  @Input() public ability: Ability;

  constructor(messageService: MessageService,
    route: ActivatedRoute,
    location: Location,
    private abilityService: AbilityService) {
      super(route, location, messageService);
      this.ability = Ability.Empty();
     }

  ngOnInit() {

  }

  add(): void {
    this.ability.name = this.ability.name.trim();
    this.ability.description = this.ability.description.trim();

    if (!this.ability.name) { return; }

    this.abilityService.addAbility(this.ability)
      .subscribe(ability => {
          console.log(this.ability, ability);
        this.ability = Ability.Empty();
        this.goBack();
      });
  }
}
