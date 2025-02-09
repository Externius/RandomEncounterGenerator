import { Directive, EventEmitter, Input, Output, HostBinding, HostListener } from '@angular/core';
import { EncounterDetailModel } from '../models/encounter.model';

export type SortDirection = 'asc' | 'desc' | '';
export type SortColumn = keyof EncounterDetailModel | '';
const rotate: { [key: string]: SortDirection } = { asc: 'desc', desc: '', '': 'asc' };

export interface SortEvent {
  column: SortColumn;
  direction: SortDirection;
}

@Directive({
  standalone: false,
  selector: 'th[sortable]'
})
export class SortableHeaderDirective {
  @Input() sortable: SortColumn = '';
  @Input() direction: SortDirection = '';
  @Output() sort = new EventEmitter<SortEvent>();

  @HostBinding('class.asc') get asc() {
    return this.direction === 'asc';
  }
  @HostBinding('class.desc') get desc() {
    return this.direction === 'desc';
  }

  @HostListener('click') rotate() {
    this.direction = rotate[this.direction];
    this.sort.emit({ column: this.sortable, direction: this.direction });
  }
}
