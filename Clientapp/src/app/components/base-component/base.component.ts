import {ActivatedRoute} from '@angular/router';
import { Location } from '@angular/common';
import {MessageService} from '../../services/message-service/message.service';

/** The Base component */
export class BaseComponent {
    protected static hasChanged: Boolean = false;

    constructor(
        private route: ActivatedRoute,
        protected location: Location,
        protected messageService: MessageService
    ) {  }

    getParam(paramName: string): string {
        return this.route.snapshot.paramMap.get(paramName);
    }

    /**
     * Redirects back to the previous page.
     */
    goBack(hasChanged: Boolean = false): void {
        BaseComponent.hasChanged = hasChanged;
        if (hasChanged) {
            this.hasChanged();
            BaseComponent.hasChanged = false;
        }
        this.location.back();
    }

    hasChanged(): void {
        console.log('has changed');
    }
}
