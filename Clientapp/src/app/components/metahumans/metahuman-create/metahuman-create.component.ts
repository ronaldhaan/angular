import { Component, OnInit } from '@angular/core';
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
  metahuman: Metahuman[];
  private MetahumanService: MetahumanService;

  constructor(metaService: MetahumanService,
    route: ActivatedRoute,
    messageService: MessageService,
    location: Location) {
    super(route, location, messageService);
    this.MetahumanService = metaService;
    this.metahuman = [];
  }

  ngOnInit() {
  }

  /**
   * Creates a new Metahuman.
   * @param name The name of the new Metahuman.
   */
  add(newMeta: Metahuman): void {
    newMeta.name = newMeta.name.trim();
    newMeta.description = newMeta.description.trim();
    newMeta.alterEgo = newMeta.alterEgo.trim();


    this.MetahumanService.addMeta(newMeta)
      .subscribe(meta => {
        this.metahuman.push(meta);
        this.goBack();
      });
  }

  handleForm(name: string, description: string, ego: string): void {

    if (!name) { return; }

    const meta: Metahuman = {
      name: name,
      description: description,
      alterEgo: ego
    } as Metahuman;

    this.add(meta);
  }

}
