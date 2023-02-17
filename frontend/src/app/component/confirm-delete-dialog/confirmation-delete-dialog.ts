import { MatDialog, MatDialogRef } from '@angular/material';
import {Component, Inject} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
@Component({
    selector: 'confirm-dialog',
    templateUrl: './confirmation-delete-dialog.html',
  })
  export class ConfirmationDeleteDialogComponent {

    // constructor(@Inject(MAT_DIALOG_DATA) public data: {name: string}) { }
    constructor(public dialogRef: MatDialogRef<ConfirmationDeleteDialogComponent>) {}
  
    public confirmMessage:string | undefined;

    // onOpen(){
    //   this.confirmMessage = 'Are you sure you want to delete?';
    // }

    // onClose(confirm : boolean){
    //   if(confirm){

    //   }
    //   else{

    //   }

    // }

    test(){
      
    }

  }