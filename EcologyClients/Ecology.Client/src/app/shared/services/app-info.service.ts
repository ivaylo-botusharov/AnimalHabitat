import { Injectable } from '@angular/core';
import { LocalizationMessageService } from '../../localization-message.service';

@Injectable()
export class AppInfoService {
  constructor(private messageService: LocalizationMessageService) {}

  public get title() {
    return this.messageService.ecologyMenuTitle;
  }
}
