import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { OwnerService } from 'src/app/service/owner.service';
import { Horse } from 'src/app/dto/horse';
import { Owner } from 'src/app/dto/owner';
import { Route, Router } from '@angular/router';
import { ConfirmationDeleteDialogComponent } from '../confirm-delete-dialog/confirmation-delete-dialog';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrls: ['./owner.component.scss']
})
export class OwnerComponent implements OnInit {
  search = false;
  owners: Owner[] = [];
  owner: Owner = {
    firstName: '',
    lastName: '',
    email: ''
  }

  bannerError: string | null = null;
  constructor(
    private service: OwnerService,
    private notification: ToastrService,
    private router: Router,
    private dialog: MatDialog,
  
  ) { }

  ngOnInit(): void {
    this.reloadOwners();
  }

  onDelete(id: number, owner: Owner) {

      const dialogRef = this.dialog.open(ConfirmationDeleteDialogComponent,{
        data: { confirmAction: 'delete',
                subject: owner 
        }
      });

      dialogRef.afterClosed().subscribe(() => {
        
        if(dialogRef.componentInstance.isConfirmed){
          this.service.delete(id, owner)
            .subscribe({
              next: data => {
                this.owner = data
                this.notification.success(`Owner ${this.owner.firstName} ${this.owner.lastName} successfully deleted.`);
                this.router.navigate(['/owners']);
                this.reloadOwners();
                
              },
              error: error => {
                console.error('Error deleting owner', error);
                this.bannerError = 'Could not delete owner: ' + error.message;
              }
            });
  
        }
      });
      
  

      
  }

  reloadOwners() {
    this.service.getAll()
      .subscribe({
        next: data => {
          this.owners = data;
        },
        error: error => {
          console.error('Error fetching owners', error);
          this.bannerError = 'Could not fetch owners: ' + error.message;
          const errorMessage = error.status === 0
            ? 'Is the backend up?'
            : error.message.message;
          this.notification.error(errorMessage, 'Could Not Fetch owners');
        }
      });

  }



}

