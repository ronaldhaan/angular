import { Component, OnInit } from '@angular/core';
import {MetahumanService} from '../../../services/metahuman-service/metahuman.service';
import {Metahuman} from '../../../models/metahuman';
import {ActivatedRoute} from '@angular/router';
import {Location} from '@angular/common';
import {MessageService} from '../../../services/message-service/message.service';
import {BaseComponent} from '../../base-component/base.component';
import {TeamService} from '../../../services/team-service/team.service';
import {TeamMetahumanService} from '../../../services/team-metahuman-service/team-metahuman.service';
import {Team} from '../../../models/team';

@Component({
  selector: 'app-team-metahuman-add',
  templateUrl: './team-metahuman-add.component.html',
  styleUrls: ['./team-metahuman-add.component.css']
})
export class TeamMetahumanAddComponent extends BaseComponent implements OnInit {
  public metahumen$: Metahuman[];
  public team: Team;
  public metas: Metahuman[];

  constructor(
      route: ActivatedRoute,
      location: Location,
      messageService: MessageService,
      public metaService: MetahumanService,
      public teamService: TeamService,
      public teamAbilityService: TeamMetahumanService
  ) {
    super(route, location, messageService);

    this.team = Team.Empty();
    this.metas = [];
    this.metahumen$ = [];
  }

  ngOnInit() {
    this.getData();
    this.location.subscribe(() => {
      this.getData();
    });
  }

  push(meta: Metahuman): void {
    if (this.metahumen$.indexOf(meta) === -1) {
      this.metahumen$.push(meta);
    } else {
      this.messageService.add(`${meta.name} is already chosen.`, 2000);
    }
  }

  remove(meta: Metahuman): void {
    if (this.metahumen$.length === 1) {
      if (this.metahumen$[0].id === meta.id) {
        this.metahumen$ = [];
      }
    }
    for (let i = 0; i < this.metahumen$.length - 1; i++) {
      if ( this.metahumen$[i].id === meta.id) {
        this.metahumen$.splice(i, 1);
      }
    }
  }

  getData() {
    const id = this.getParam('id');
    this.teamService.getOne(id)
        .subscribe(team => {
          this.team = team;
          this.getMetahumans();
        });
  }

  getMetahumans() {
    this.metaService.getMetas().subscribe(metas => {
      metas.forEach(meta => {
        let hasMember = false;
        this.team.metahumans.forEach(teamMeta => {
          if (meta.id === teamMeta.id) {
            hasMember = true;
          }
        });

        if (!hasMember) {
          this.metas.push(meta);
        }
      });
    });

    console.log('team', this.team);
  }

  add(): void {
    if (this.metahumen$.length > 0) {
      const id = this.getParam('id');
      let i = 1;
      this.metahumen$
          .forEach(
              meta => this.teamAbilityService.add(id, meta).subscribe(() => {
                if (i === this.metahumen$.length) {
                  this.goBack();
                  return;
                }
                i++;
              })
          );
    } else {
      this.messageService.add('First you need to choose an meta human', 2000);
    }
  }

}
