import { Component } from '@angular/core';
import {ActivatedRoute, Event as NavigationEvent, NavigationEnd} from '@angular/router';
import { Router } from '@angular/router';
import {BaseComponent} from './components/base-component/base.component';
import {MessageService} from './services/message-service/message.service';
import { Location} from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent extends BaseComponent {
    public readonly routes = [
      { link: '/dashboard', name: 'Dashboard' },
      { link: '/metas', name: 'Metas' },
      { link: '/abilities', name: 'Abilities' },
      { link: '/teams', name: 'Teams' }
    ];
  constructor( router: Router,
               route: ActivatedRoute,
               location: Location,
               messageService: MessageService) {
    super(route, location, messageService);
  }
}
