import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { EncounterDetailModel } from '../../shared/models/encounter.model';
import { EncounterService } from '../../core/http/encounter.service';

@Component(
  {
    selector: 'app-encounter-detail',
    templateUrl: './encounter.detail.component.html',
    providers: [EncounterService]
  })
export class EncounterDetailComponent {

  @Input() detail: EncounterDetailModel;

  constructor(public activeModal: NgbActiveModal) {
  }

  calcMod(ability: number): string {
    const result = -5 + Math.floor(ability / 2);
    if (result > 0) {
      return '+' + result;
    }
    return result.toString();
  }

  onConfirm(): void {
    this.activeModal.close(true);
  }

  onDismiss(): void {
    this.activeModal.close(true);
  }

}
