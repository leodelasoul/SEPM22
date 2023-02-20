import { MatDialog, MatDialogRef } from '@angular/material';
import {Component, Inject} from '@angular/core';
import { Owner } from 'src/app/dto/owner';
import { Horse } from 'src/app/dto/horse';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
@Component({
    selector: 'confirm-dialog',
    templateUrl: './confirmation-delete-dialog.html',
  })
  export class ConfirmationDeleteDialogComponent {
    private subject: any;
    public isConfirmed: boolean = false; //referenced in owner component
    private confirmAction: string = "";  
 

    constructor(public dialogRef: MatDialogRef<ConfirmationDeleteDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: ConfirmationDeleteDialogComponent) {
      this.subject = data.subject;
      this.subjectName
      this.confirmAction = data.confirmAction;
    }

    public get subjectName(){
      if(this.instanceOfOwner(this.subject)){
          return "Owner: " + this.subject.firstName + " " + this.subject.lastName // Owner, try more generic approach 
      }
      else{
        return "Horse: " + this.subject.name // Horse

      }
    }

    instanceOfOwner(object: any): object is Owner {
      return 'email' in object;
    }

   

    onConfirmClick(): void{
      console.log(this.data)
      this.isConfirmed = true;
      this.dialogRef.close();

    }

    onNoClick(): void {
      this.isConfirmed = false;
      console.log(this.data)
      this.dialogRef.close();
    }
  }