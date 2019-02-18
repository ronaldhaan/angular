import {Component, Input, OnInit} from '@angular/core';
import { Location } from '@angular/common';
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
  @Input() public team: Team;

  constructor(
      route: ActivatedRoute,
      location: Location,
      messageService: MessageService,
      private teamService: TeamService
  ) {
    super(route, location, messageService);
    this.team = Team.Empty();
  }

  ngOnInit() {
  }

  /**
   * Creates a new `Team`.
   * @param team The name of the new `Team`.
   */
  add(): void {
    this.team.name = this.team.name.trim();
    this.team.description = this.team.description.trim();


    if (!this.team.name) { return; }
    console.log(this.team);
    this.teamService.add(this.team)
        .subscribe(() => {
          this.goBack();
        });
  }


}
