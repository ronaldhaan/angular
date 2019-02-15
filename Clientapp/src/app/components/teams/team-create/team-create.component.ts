import { Component, OnInit } from '@angular/core';
import { Location } from  '@angular/common';
import { BaseComponent } from '../../base-component/base.component';
import { ActivatedRoute } from '@angular/router';
import { TeamService } from '../../../services/team-service/team.service';
import {MessageService} from '../../../services/message-service/message.service';
import { Team } from '../../../models/team';

@Component({
  selector: 'app-team-create',
  templateUrl: './team-create.component.html',
  styleUrls: ['./team-create.component.css']
})
export class TeamCreateComponent extends BaseComponent implements OnInit {
  private teamService: TeamService;

  constructor(
      route: ActivatedRoute,
      location: Location,
      messageService: MessageService,
      teamService: TeamService
  ) {
    super(route, location, messageService);
    this.teamService = teamService;
  }

  ngOnInit() {
  }

  /**
   * Creates a new Metahuman.
   * @param name The name of the new Metahuman.
   */
  add(team: Team): void {
    team.name = team.name.trim();
    team.description = team.description.trim();
    console.log(team);
    this.teamService.add(team)
        .subscribe(meta => {
          this.goBack(true);
        });
  }

  handleForm(name: string, description: string): void {

    if (!name) { return; }

    const team = {
      name: name,
      description: description
    } as  Team;

    this.add(team);
  }


}
