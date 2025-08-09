import {Component, OnInit, ViewChildren, QueryList} from '@angular/core';
import {EncounterListService} from './encounter.list.service';
import {
  EncounterOptionModel,
  EncounterModel,
  EncounterDetailModel,
  SpecialAbility,
  Action,
  Reaction,
  LegendaryAction
} from '../../shared/models/encounter.model';
import {FormGroup, FormBuilder} from '@angular/forms';
import {SortEvent, SortableHeaderDirective} from '../../shared/directive/sortable.directive';
import {faDiceD20} from '@fortawesome/free-solid-svg-icons';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {EncounterDetailComponent} from './encounter.detail.component';

const compare = (
  v1: string | number | SpecialAbility[] | Action[] | Reaction[] | LegendaryAction[],
  v2: string | number | SpecialAbility[] | Action[] | Reaction[] | LegendaryAction[]
) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

@Component({
  selector: 'app-encounter',
  templateUrl: './encounter.list.component.html',
  standalone: false,
  providers: [EncounterListService]
})
export class EncounterListComponent implements OnInit {
  _monsterTypes!: [];
  _sizes!: [];
  difficulties!: [];
  partyLevels: number[] = [];
  partySizes: number[] = [];
  _originalDetails: EncounterDetailModel[] = [];
  serverError = '';
  encounterOptionsForm!: FormGroup;
  encounterModel: EncounterModel = new EncounterModel();
  @ViewChildren(SortableHeaderDirective) headers!: QueryList<SortableHeaderDirective>;
  faDiceD20 = faDiceD20;

  constructor(
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    public encounterListService: EncounterListService
  ) {
    for (let level = 1; level < 21; level++) {
      this.partyLevels.push(level);
    }
    for (let i = 1; i < 11; i++) {
      this.partySizes.push(i);
    }
  }

  ngOnInit() {
    this.encounterListService.getMonsterTypes().subscribe((data) => {
      this._monsterTypes = data as [];
    });
    this.encounterListService.getDifficulties().subscribe((data) => {
      this.difficulties = data as [];
    });
    this.encounterListService.getSizes().subscribe((data) => {
      this._sizes = data as [];
    });
    this.encounterOptionsForm = this.formBuilder.group(new EncounterOptionModel());
  }

  onSubmit() {
    // workaround for first empty select
    if (this.encounterOptionsForm.value.monsterTypes === null) {
      this.encounterOptionsForm.value.monsterTypes = [];
    }
    if (this.encounterOptionsForm.value.sizes === null) {
      this.encounterOptionsForm.value.sizes = [];
    }

    this.encounterListService.generate(JSON.stringify(this.encounterOptionsForm.value)).subscribe({
      next: (data) => {
        Object.assign(this.encounterModel, data);
        this._originalDetails = [];
        Object.assign(this._originalDetails, this.encounterModel.encounters);
      },
      error: (error) => {
        this.serverError = error.error.Message;
      },
      complete: () => {
        return;
      }
    });
  }

  onSort({column, direction}: SortEvent) {
    this.headers.forEach((header) => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    if (direction === '' || column === '') {
      this.encounterModel.encounters = this._originalDetails;
    } else {
      this.encounterModel.encounters = [...this._originalDetails].sort((a, b) => {
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
