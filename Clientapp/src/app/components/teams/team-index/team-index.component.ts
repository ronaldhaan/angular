import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import {BaseComponent} from '../../base-component/base.component';
import {ActivatedRoute} from '@angular/router';
import {TeamService} from '../../../services/team-service/team.service';
import {Team} from '../../../models/team';
import {MessageService} from '../../../services/message-service/message.service';

@Component({
  selector: 'app-team-index',
  templateUrl: './team-index.component.html',
  styleUrls: ['./team-index.component.css']
})
export class TeamIndexComponent extends BaseComponent implements OnInit {

  private service: TeamService;
  private teams: Team[];

  constructor(
      route: ActivatedRoute,
      location: Location,
      messageService: MessageService,
      service: TeamService
  ) {
    super(route, location, messageService);
    this.service = service;
    this.teams = [];
  }

  ngOnInit() {
    this.getTeams();
  }

  getTeams(): void {
    this.service.getAll().subscribe(teams => this.teams = teams);
  }



  delete(team: Team): void {

    this.service.delete(team).subscribe();
  }

}
