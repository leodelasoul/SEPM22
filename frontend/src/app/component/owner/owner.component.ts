import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { OwnerService } from 'src/app/service/owner.service';
import { Horse } from 'src/app/dto/horse';
import { Owner } from 'src/app/dto/owner';

@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrls: ['./owner.component.scss']
})
export class OwnerComponent implements OnInit {
  search = false;
  owners: Owner[] = [];
  bannerError: string | null = null;
  
  constructor(
    private service: OwnerService,
    private notification: ToastrService,
  ) { }


  ngOnInit(): void {
    this.reloadOwners();
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

