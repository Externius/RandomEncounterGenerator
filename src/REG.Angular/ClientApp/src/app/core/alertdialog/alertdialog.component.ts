import {Component, Input} from '@angular/core';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {TranslatePipe} from "@ngx-translate/core";

@Component({
  selector: 'app-alert-dialog',
  imports: [TranslatePipe],
  templateUrl: './alertdialog.component.html'
})

export class AlertDialogComponent {
  @Input() title = '';
  @Input() message = '';
  @Input() stackTrace = '';

  constructor(public activeModal: NgbActiveModal) {
  }

  onConfirm(): void {
    this.activeModal.close(true);
  }

  onDismiss(): void {
    this.activeModal.dismiss(true);
  }
}
