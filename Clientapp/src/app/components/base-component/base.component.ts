import {Component, NgModule} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import {MessageService} from '../../services/message-service/message.service';
import { NavigationStart } from '@angular/router';
import { TruncatePipe } from '../../Pipes/truncate-pipe';
import {AppModule} from '../../app.module';

/** The Base component */
export class BaseComponent {
    protected static hasChanged: Boolean = false;
    private route: ActivatedRoute;
    protected location: Location;

    protected messageService: MessageService;

    constructor(
        route: ActivatedRoute,
        location: Location,
        messageService: MessageService
    ) {
        this.route = route;
        this.location = location;
        this.messageService = messageService;
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

    onPageReturn(event: NavigationStart): void {
        console.log('return to ', event.restoredState.navigationId);
    }
}
