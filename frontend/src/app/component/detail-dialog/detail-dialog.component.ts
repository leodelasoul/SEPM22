import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material';
import { Owner } from 'src/app/dto/owner';
import { ConfirmationDeleteDialogComponent } from '../confirm-delete-dialog/confirmation-delete-dialog';
@Component({
  selector: 'app-detail-dialog',
  templateUrl: './detail-dialog.component.html',
  styleUrls: ['./detail-dialog.component.scss']
})
export class DetailDialogComponent extends ConfirmationDeleteDialogComponent implements OnInit {
  

  constructor(public dialogRef: MatDialogRef<DetailDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: DetailDialogComponent) {
    super(dialogRef, data);
  }


  ngOnInit(): void {
  }

}
