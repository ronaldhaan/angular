import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
// components
import { BaseComponent } from 'src/app/components/base-component/base.component';

import { Metahuman } from 'src/app/models/metahuman';
import { MetahumanService } from 'src/app/services/metahuman-service/metahuman.service';
import {MessageService} from '../../../services/message-service/message.service';

@Component({
  selector: 'app-metahuman-index',
  templateUrl: './metahuman-index.component.html',
  styleUrls: ['./metahuman-index.component.css']
})
export class MetaHumanIndexComponent extends BaseComponent implements OnInit {
  private filteredMetas: Metahuman[];
  public metahumans: Metahuman[];

  private metahumanService: MetahumanService;
  public metaStatus: string[] = ['All', 'Hero', 'Villain', 'Antihero'];
  public status = -1;

  constructor(
    route: ActivatedRoute,
    metahumanService: MetahumanService,
    location: Location,
    messageService: MessageService
  ) {
    super(route, location, messageService);
    this.metahumanService = metahumanService;
    this.metahumans = [];
  }


  ngOnInit() {
    this.getMetahumans();
    this.location.subscribe(() => {
      this.getMetahumans();
    });
  }
  /**
   * Gets the metahumans.
   */
  getMetahumans(): void {
    this.metahumanService.getMetas()
    .subscribe(metahumans => { this.metahumans = metahumans; this.filteredMetas = metahumans; });
  }

  /**
   * Deletes a metahuman.
   * @param metahuman the metahuman that's about to be deleted
   */
  delete(metahuman: Metahuman): void {
    this.metahumans = this.metahumans.filter(h => h !== metahuman);
    this.filteredMetas = this.filteredMetas.filter( m => m !== metahuman);
    this.metahumanService.deleteMeta(metahuman).subscribe();
  }

  search(status: number): void {
    this.status = status;
    if (status === -1) {
      this.filteredMetas = this.metahumans;
    } else if (status <= 2) {
      this.filteredMetas = this.metahumans.filter(m => m.status === status);
    }
  }
}
