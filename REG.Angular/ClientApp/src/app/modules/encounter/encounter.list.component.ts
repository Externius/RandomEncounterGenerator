import { Component, OnInit, ViewChildren, QueryList } from '@angular/core';
import { EncounterListService } from './encounter.list.service';
import { EncounterOptionModel, EncounterModel, EncounterDetailModel } from '../../shared/models/encounter.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { SortEvent, SortableHeaderDirective } from '../../shared/directive/sortable.directive';
import { faInfoCircle } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EncounterDetailComponent } from './encounter.detail.component';

export const compare = (v1, v2) => v1 < v2 ? -1 : v1 > v2 ? 1 : 0;

@Component({
  selector: 'app-encounter',
  templateUrl: './encounter.list.component.html',
  providers: [EncounterListService]
})
export class EncounterListComponent implements OnInit {
  _monsterTypes: any[];
  difficulties: any[];
  partyLevels: number[] = [];
  partySizes: number[] = [];
  _orignialDetails: EncounterDetailModel[] = [];
  serverError = '';
  encounterOptionsForm: FormGroup;
  encounterOptions: EncounterOptionModel = new EncounterOptionModel();
  encounterModel: EncounterModel = new EncounterModel();
  @ViewChildren(SortableHeaderDirective) headers: QueryList<SortableHeaderDirective>;
  faInfoCircle = faInfoCircle;

  constructor(
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    public encounterListService: EncounterListService) {
    for (let level = 1; level < 21; level++) {
      this.partyLevels.push(level);
    }
    for (let i = 1; i < 11; i++) {
      this.partySizes.push(i);
    }
  }

  ngOnInit() {
    this.encounterListService.getMonsterTypes()
      .subscribe(data => {
        this._monsterTypes = data as any[];
      });
    this.encounterListService.getDifficulties()
      .subscribe(data => {
        this.difficulties = data as any[];
      });
    this.encounterOptionsForm = this.formBuilder.group(this.encounterOptions);
  }

  onSubmit() {
    if (this.encounterOptionsForm.value.monsterTypes == null) { // workaround for first empty select
      this.encounterOptionsForm.value.monsterTypes = [];
    }

    this.encounterListService.generate(JSON.stringify(this.encounterOptionsForm.value))
      .subscribe(
        (data: JSON) => {
          Object.assign(this.encounterModel, data);
          Object.assign(this._orignialDetails, this.encounterModel.encounters);
        },
        (error) => {
          this.serverError = (error.error.Message);
          console.log(this.serverError);
        });
  }

  onSort({ column, direction }: SortEvent) {
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    if (direction === '') {
      this.encounterModel.encounters = this._orignialDetails;
    } else {
      this.encounterModel.encounters = [...this._orignialDetails].sort((a, b) => {
        const res = compare(a[column], b[column]);
        return direction === 'asc' ? res : -res;
      });
    }
  }

  monsterDetailDialog(detail: EncounterDetailModel) {
    const modalRef = this.modalService.open(EncounterDetailComponent, {
      size: 'xl',
      scrollable: true
    });
    modalRef.componentInstance.detail = detail;
  }

}
