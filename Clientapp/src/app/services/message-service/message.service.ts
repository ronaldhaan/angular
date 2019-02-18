import { Injectable } from '@angular/core';
import { Utilities, Object} from '../../utilities';

class Message {
  public id: number;
  public message: string;
  public interval?: any;
}

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  messages: Message[] = [];

  add(message: string, interval?: number) {
    const id: number = Utilities.getUniqueId(0, this.messages as Object[]);

    const newMessage: Message = {
      id: id,
      message: message,
    };

    this.messages.push(newMessage);

    if (interval) {
      newMessage.interval = setInterval(() => {
        this.remove(newMessage.id);
        clearInterval(newMessage.interval);
      }, interval);
    }

    return id;
  }

  /**
   * Remove an message from the list.
   *
   * @param message the message to be removed.
   */
  remove(id: number): void {
    if (this.messages.length === 1) {
      if (this.messages[0].id === id) {
        this.messages = [];
      }
    }

    for (let i = 0; i < this.messages.length - 1; i++) {
      if ( this.messages[i].id === id) {
        this.messages.splice(i, 1);
      }
    }
  }

  clear() {
    this.messages = [];
  }
}
