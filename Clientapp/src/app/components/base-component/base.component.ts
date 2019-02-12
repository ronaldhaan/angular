// import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

/** The Base component */
export class BaseComponent {
    protected static hasChanged: Boolean = false;
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
    goBack(hasChanged: Boolean = false): void {
        BaseComponent.hasChanged = hasChanged;
        this.hasChanged();
        this.location.back();
    }

    hasChanged(): void {
        console.log('has changed');
    }
}
