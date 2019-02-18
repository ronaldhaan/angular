import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base-component/base.component';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Metahuman } from 'src/app/models/metahuman';
import { Ability } from 'src/app/models/ability';
import { AbilityService } from 'src/app/services/ability-service/ability.service';
import { MetahumanService } from 'src/app/services/metahuman-service/metahuman.service';
import { MetahumanAbilityService } from 'src/app/services/metahuman-ability-service/metahuman-ability.service';
import {MessageService} from '../../../services/message-service/message.service';

@Component({
  selector: 'app-meta-ability-add',
  templateUrl: './metahuman-ability-add.component.html',
  styleUrls: ['./metahuman-ability-add.component.css']
})
export class MetahumanAbilityAddComponent extends BaseComponent implements OnInit {

  public abilityService: AbilityService;
  public metaService: MetahumanService;
  public metaAbilityService: MetahumanAbilityService;

  public chosenAbilities: Ability[];

  public meta: Metahuman;
  public abilities: Ability[];

  constructor(
    route: ActivatedRoute,
    location: Location,
    messageService: MessageService,
    abilityService: AbilityService,
    metaService: MetahumanService,
    haService: MetahumanAbilityService
  ) {
    super(route, location, messageService);
    this.abilityService = abilityService;
    this.metaService = metaService;
    this.metaAbilityService = haService;

    this.meta = Metahuman.Empty();
    this.abilities = [];
    this.chosenAbilities = [];
   }

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.getMeta();
  }

  push(ability: Ability): void {
    if (this.chosenAbilities.indexOf(ability) === -1) {
      this.chosenAbilities.push(ability);
    } else {
      // TODO give message back
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

  getMeta() {
    const id = this.getParam('id');
    this.metaService.getMeta(id)
            .subscribe(meta => {
              this.meta = meta;
              this.getAbilities();
            });
  }

  getAbilities() {
    this.abilityService.getAbilities().subscribe(abilities => {
        abilities.forEach(ability => {
          let hasAbility = false;
          this.meta.abilities.forEach(metaAbility => {
            if (ability.id === metaAbility.id) {
              hasAbility = true;
            }
          });

          if (!hasAbility) {
            this.abilities.push(ability);
          }
        });
    });

    console.log('meta', this.meta);
  }

  add(): void {
    if (this.chosenAbilities.length > 0) {
      const id = this.getParam('id');
      this.chosenAbilities
          .forEach(
              ability => this.metaAbilityService.add(ability, id).subscribe()
          );
      this.goBack();
    } else {
      this.messageService.add('First you need to choose an ability');
    }
  }

}
