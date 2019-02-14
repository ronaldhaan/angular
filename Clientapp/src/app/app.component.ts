import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  routes = [
    { link: '/dashboard', name: 'Dashboard' },
    { link: '/metas', name: 'Metas' },
    { link: '/abilities', name: 'Abilities' },
    { link: '/teams', name: 'Teams' }
  ];
}
