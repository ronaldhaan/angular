import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { Metahuman } from '../../models/metahuman';
import { MetahumanService } from '../../services/metahuman-service/metahuman.service';
import {BaseComponent} from '../base-component/base.component';
import {ActivatedRoute} from '@angular/router';
import {MessageService} from '../../services/message-service/message.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.css' ]
})
export class DashboardComponent extends BaseComponent implements OnInit {
  metahumen: Metahuman[] = [];

  constructor( route: ActivatedRoute,
      location: Location,
      messageService: MessageService,
      private metahumanService: MetahumanService) {
      super(route, location, messageService);
  }

  ngOnInit() {
    this.getMetas();
  }

  /**
   * Gets all metahumans.
   */
  getMetas(): void {
    this.metahumanService.getMetas()
      .subscribe(metahuman => this.metahumen = metahuman.slice(1, 5));
  }
}
