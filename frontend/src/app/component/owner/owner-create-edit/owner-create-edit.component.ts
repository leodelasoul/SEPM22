import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Owner } from 'src/app/dto/owner';
import { HorseService } from 'src/app/service/horse.service';
import { OwnerService } from 'src/app/service/owner.service';

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

  constructor(private horseService: HorseService,
    private service: OwnerService,
    private router: Router,
    private route: ActivatedRoute,
    private notification: ToastrService,) { }

  mode: OwnerCreateEditMode = OwnerCreateEditMode.create;
  owner: Owner = {
    firstName: '',
    lastName: '',
    email: ''
    };



  public get heading(): string {
    switch (this.mode) {
      case OwnerCreateEditMode.create:
        return 'Create New Owner';
      case OwnerCreateEditMode.edit:
        return 'Edit New Owner';
      default:
        return '?';
    }
  }
  get modeIsCreate(): boolean {
    return true ? this.mode === OwnerCreateEditMode.create : false;
  }

  private get modeActionFinished(): string {
    switch (this.mode) {
      case OwnerCreateEditMode.create:
        return 'created';
      case OwnerCreateEditMode.edit:
        return 'updated'
      default:
        return '?';
    }
  }
  public get submitButtonText(): string {
    switch (this.mode) {
      case OwnerCreateEditMode.create:
        return 'Create';
      case OwnerCreateEditMode.edit:
        return 'Edit';
      default:
        return '?';
    }
  }



  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.mode = data.mode;
    });
  }


  public onSubmit(form: NgForm): void {
    console.log('is form valid?', form.valid, this.owner);
    if (form.valid) {
      if (this.owner.email === '') {
        delete this.owner.email;
      }
      let observable: Observable<Owner>;
      switch (this.mode) {
        case OwnerCreateEditMode.create:
          observable = this.service.create(this.owner);
          break;
        default:
          console.error('Unknown HorseCreateEditMode', this.mode);
          return;
      }
      observable.subscribe({
        next: data => {
          this.notification.success(`Owner ${this.owner.firstName} successfully ${this.modeActionFinished}.`);
          this.router.navigate(['/owners']);
        },
        error: error => {
          console.error('Error creating horse', error);
          // TODO show an error message to the user. Include and sensibly present the info from the backend!
        }
      });
    }
  }

}
