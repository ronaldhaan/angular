import {Component, Input, OnInit} from '@angular/core';
import { BaseComponent } from '../../base-component/base.component';
import {ActivatedRoute, NavigationEnd, NavigationStart} from '@angular/router';
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
  @Input() team: Team;

  constructor(route: ActivatedRoute,
              location: Location,
              messageService: MessageService,
              private teamService: TeamService,
              private teamMetahumanService: TeamMetahumanService) {
    super(route, location, messageService);
    this.team = Team.Empty();
  }

  ngOnInit() {
    this.getTeam();
    // this.location.subscribe(() => {
    //   this.getTeam();
    // });
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
    console.log('overriding hasChanged in', typeof this);
  }

}
