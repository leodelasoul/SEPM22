import { Component, OnInit } from '@angular/core';

export enum OwnerCreateEditMode {
  create,
  edit,
};
@Component({
  selector: 'app-owner-create-edit',
  templateUrl: './owner-create-edit.component.html',
  styleUrls: ['./owner-create-edit.component.scss']
})
export class OwnerCreateEditComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
