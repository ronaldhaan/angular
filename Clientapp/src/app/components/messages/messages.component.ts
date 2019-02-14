import { Component, OnInit } from '@angular/core';
import {MessageService} from '../../services/message-service/message.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {

  public messageService: MessageService;

  constructor(service: MessageService) {
    this.messageService = service;
  }

  ngOnInit() {
  }

}
