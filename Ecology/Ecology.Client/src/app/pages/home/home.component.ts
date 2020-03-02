import { Component } from '@angular/core';
import { LocalizationMessageService } from '../../localization-message.service'

@Component({
  templateUrl: 'home.component.html',
  styleUrls: [ './home.component.scss' ]
})

export class HomeComponent {
  constructor(private messageService: LocalizationMessageService) {}

  helloWorld() {
    alert('Hello world!');
  }
}
