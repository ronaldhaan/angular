import {Component, Input, OnInit} from '@angular/core';
import { Location } from '@angular/common';

import { Metahuman } from 'src/app/models/metahuman';
import { MetahumanService } from 'src/app/services/metahuman-service/metahuman.service';
import { BaseComponent } from '../../base-component/base.component';
import { ActivatedRoute } from '@angular/router';
import {MessageService} from '../../../services/message-service/message.service';

@Component({
  selector: 'app-metahuman-create',
  templateUrl: './metahuman-create.component.html',
  styleUrls: ['./metahuman-create.component.css']
})
export class MetahumanCreateComponent extends BaseComponent implements OnInit {
  @Input() metahuman: Metahuman;
  private MetahumanService: MetahumanService;

  constructor(metaService: MetahumanService,
    route: ActivatedRoute,
    messageService: MessageService,
    location: Location) {
    super(route, location, messageService);
    this.MetahumanService = metaService;
    this.metahuman = Metahuman.Empty();
  }

  ngOnInit() {
  }

  /**
   * Creates a new Metahuman.
   */
  add(): void {
    this.metahuman.name = this.metahuman.name.trim();
    this.metahuman.description = this.metahuman.description.trim();
    this.metahuman.alterEgo = this.metahuman.alterEgo.trim();

    if (!this.metahuman.name) { return; }

    this.MetahumanService.addMeta(this.metahuman)
      .subscribe(() => {
        this.metahuman = Metahuman.Empty();
        this.goBack();
      });
  }

}
