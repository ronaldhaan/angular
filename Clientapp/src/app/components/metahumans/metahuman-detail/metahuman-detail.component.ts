import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
// components
import { Metahuman } from 'src/app/models/metahuman';
import { MetahumanService } from 'src/app/services/metahuman-service/metahuman.service';
import { BaseComponent } from 'src/app/components/base-component/base.component';
import {Ability} from 'src/app/models/ability';
import {MetahumanAbilityService} from 'src/app/services/metahuman-ability-service/metahuman-ability.service';
import {MessageService} from '../../../services/message-service/message.service';

@Component({
  selector: 'app-metahuman-detail',
  templateUrl: './metahuman-detail.component.html',
  styleUrls: [ './metahuman-detail.component.css' ]
})
export class MetahumanDetailComponent extends BaseComponent implements OnInit {
  @Input() public meta: Metahuman;

  private metaService: MetahumanService;
  private metaAbilityService: MetahumanAbilityService;
  public metaStatus: string[] = ['hero', 'villain', 'antihero'];

  constructor(
    route: ActivatedRoute,
    location: Location,
    metaService: MetahumanService,
    messageService: MessageService,
    haService: MetahumanAbilityService
  ) {
    super(route, location, messageService);
    this.metaService = metaService;
    this.metaAbilityService = haService;
    this.meta = Metahuman.Empty();
  }


  ngOnInit(): void {
    this.getMeta();
    this.location.subscribe(x => {
      this.getMeta();
    });
  }

  /**
   * Gets the meta from the url.
   */
  getMeta(): void {
    const id = this.getParam('id');

    this.metaService.getMeta(id)
          .subscribe(meta => this.meta = meta);
  }

  /**
   * Updates a meta.
   */
  save(): void {
    this.metaService.updateMeta(this.meta)
      .subscribe(() => this.goBack());
  }

  remove(ability: Ability): void {
    this.metaAbilityService.remove(ability, this.getParam('id')).subscribe(() =>
    this.getMeta());
  }

  hasChanged(): void {
      super.hasChanged();
      this.getMeta();
      console.log('overriding haschanged');
  }
}
