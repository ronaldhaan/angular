import { Component, OnInit } from '@angular/core';
import { Metahuman } from '../../models/metahuman';
import { MetahumanService } from '../../services/metahuman-service/metahuman.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.css' ]
})
export class DashboardComponent implements OnInit {
  metahumen: Metahuman[] = [];

  constructor(private metahumanService: MetahumanService) { }

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
