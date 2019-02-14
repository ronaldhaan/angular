import { Injectable } from '@angular/core';
import { Utilities, Object} from '../../utilities';
class Message {
  public id: number;
  public message: string;
}

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  messages: Message[] = [];

  add(message: string) {
    const id: number = Utilities.getUniqueId(0, this.messages as Object[]);

    const newMessage: Message = {
      id: id,
      message: message
    };

    this.messages.push(newMessage);

    return id;
  }

  clear() {
    this.messages = [];
  }
}
