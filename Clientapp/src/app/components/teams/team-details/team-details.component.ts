import {Component, Input, OnInit} from '@angular/core';
import { BaseComponent } from '../../base-component/base.component';
import {ActivatedRoute, NavigationStart} from '@angular/router';
import { Location } from '@angular/common';

import {Team} from '../../../models/team';
import {TeamService} from '../../../services/team-service/team.service';
import {Metahuman} from '../../../models/metahuman';
import {MessageService} from '../../../services/message-service/message.service';
import {TeamMetahumanService} from '../../../services/team-metahuman-service/team-metahuman.service';

@Component({
  selector: 'app-team-details',
  templateUrl: './team-details.component.html',
  styleUrls: ['./team-details.component.css']
})
export class TeamDetailsComponent extends BaseComponent implements OnInit {
  private teamService: TeamService;
  private teamMetahumanService: TeamMetahumanService;
  @Input() team: Team;

  constructor(route: ActivatedRoute,
              location: Location,
              service: TeamService,
              messageService: MessageService,
              metaService: TeamMetahumanService) {
    super(route, location, messageService);
    this.teamService = service;
    this.teamMetahumanService = metaService;
    this.team = Team.Empty();
  }

  ngOnInit() {
    this.getTeam();
    this.location.subscribe(x => {
      this.getTeam();
    });
  }

  getTeam() {
    const id = this.getParam('id');
    this.teamService.getOne(id)
            .subscribe(team => this.team = team);
  }

  /**
   * Updates a meta.
   */
  save(): void {
    this.teamService.update(this.team)
        .subscribe(() => this.goBack());
  }

  remove(meta: Metahuman): void {
    const teamId = this.getParam('id');
    this.teamMetahumanService.remove(teamId, meta).subscribe(() => {
      this.getTeam();
    });
  }

  hasChanged(): void {
    super.hasChanged();
    this.getTeam();
  }

  onPageReturn(event: NavigationStart): void {
    super.onPageReturn(event);
    console.log('overriding on page return in ', typeof this);
  }

}
