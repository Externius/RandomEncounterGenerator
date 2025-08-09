import {Injectable} from '@angular/core';
import {EncounterService} from '../../core/http/encounter.service';
import {Subject} from 'rxjs';
import {SortDirection} from '../../shared/directive/sortable.directive';

interface State {
  sortColumn: string;
  sortDirection: SortDirection;
}

@Injectable({providedIn: 'root'})
export class EncounterListService {
  private _search$ = new Subject<void>();
  private _state: State = {
    sortColumn: 'name',
    sortDirection: 'asc'
  };

  constructor(private service: EncounterService) {
  }

  set sortColumn(sortColumn: string) {
    this._set({sortColumn});
  }

  set sortDirection(sortDirection: SortDirection) {
    this._set({sortDirection});
  }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  public getMonsterTypes() {
    return this.service.getMonsterTypes();
  }

  public getDifficulties() {
    return this.service.getDifficulties();
  }

  public getSizes() {
    return this.service.getSizes();
  }

  public generate(data: string) {
    return this.service.generate(data);
  }

  refresh() {
    this._search$.next();
  }
}
