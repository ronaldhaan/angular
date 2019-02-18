import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../base-component/base.component';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Metahuman } from 'src/app/models/metahuman';
import { Ability } from 'src/app/models/ability';
import { AbilityService } from 'src/app/services/ability-service/ability.service';
import { MetahumanService } from 'src/app/services/metahuman-service/metahuman.service';
import { MetahumanAbilityService } from 'src/app/services/metahuman-ability-service/metahuman-ability.service';
import { MessageService } from '../../../services/message-service/message.service';

@Component({
  selector: 'app-meta-ability-add',
  templateUrl: './metahuman-ability-add.component.html',
  styleUrls: ['./metahuman-ability-add.component.css']
})
export class MetahumanAbilityAddComponent extends BaseComponent implements OnInit {
  public abilities$: Ability[];
  public meta: Metahuman;
  public abilities: Ability[];

  constructor(
    route: ActivatedRoute,
    location: Location,
    messageService: MessageService,
    public abilityService: AbilityService,
    public metaService: MetahumanService,
    public metaAbilityService: MetahumanAbilityService
  ) {
    super(route, location, messageService);

    this.meta = Metahuman.Empty();
    this.abilities = [];
    this.abilities$ = [];
   }

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.getMeta();
  }

  push(ability: Ability): void {
    if (this.abilities$.indexOf(ability) === -1) {
      this.abilities$.push(ability);
    } else {
      this.messageService.add(`${ability.name} is already chosen.`, 2000);
    }
  }

  /**
   * Remove an ability from the list.
   *
   * @param ability the ability to be removed.
   */
  remove(ability: Ability): void {
    if (this.abilities$.length === 1) {
      if (this.abilities$[0].id === ability.id) {
        this.abilities$ = [];
      }
    }
    for (let i = 0; i < this.abilities$.length - 1; i++) {
      if ( this.abilities$[i].id === ability.id) {
        this.abilities$.splice(i, 1);
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
    if (this.abilities$.length > 0) {
      const id = this.getParam('id');
      let i = 1;
      this.abilities$
          .forEach(ability => this.metaAbilityService.add(ability, id)
              .subscribe( () => {
                if (i === this.abilities$.length) {
                  this.goBack();
                }
                i++;
              })
          );
    } else {
      this.messageService.add('First you need to choose an ability', 2000);
    }
  }

}
