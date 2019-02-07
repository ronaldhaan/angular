// import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

/** The Base component */
export class BaseComponent {
    private route: ActivatedRoute;
    private location: Location;

    constructor(
        route: ActivatedRoute,
        location: Location
    ) {
        this.route = route;
        this.location = location;
     }

    getParam(paramName: string): string {
        return this.route.snapshot.paramMap.get(paramName);
    }

    /** 
     * Redirects back to the previous page.
     */
    goBack(): void {
        this.location.back();
    }
}