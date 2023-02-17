import {Component, OnInit} from '@angular/core';
import {ToastrService} from 'ngx-toastr';
import {HorseService} from 'src/app/service/horse.service';
import {Horse} from '../../dto/horse';
import {Owner} from '../../dto/owner';
import { Sex } from 'src/app/dto/sex';
import { Router } from '@angular/router';

@Component({
  selector: 'app-horse',
  templateUrl: './horse.component.html',
  styleUrls: ['./horse.component.scss']
})
export class HorseComponent implements OnInit {
  search = false;
  horses: Horse[] = [];
  horse: Horse = {
    name: '',
    dateOfBirth: new Date(),
    sex: Sex.female
  };
  bannerError: string | null = null;

  constructor(
    private service: HorseService,
    private notification: ToastrService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.reloadHorses();
  }

  reloadHorses() {
    this.service.getAll()
      .subscribe({
        next: data => {
          this.horses = data;
        },
        error: error => {
          console.error('Error fetching horses', error);
          this.bannerError = 'Could not fetch horses: ' + error.message;
          const errorMessage = error.status === 0
            ? 'Is the backend up?'
            : error.message.message;
          this.notification.error(errorMessage, 'Could Not Fetch Horses');
        }
      });
  }

  delete(id: number, horse: Horse) {
    this.service.delete(id, horse)
      .subscribe({
        next: data => {
          console.log(data);
          this.notification.success(`Horse ${this.horse.name} successfully deleted.`);
          this.router.navigate(['/horses']);
          this.reloadHorses();
          
        },
        error: error => {
          console.error('Error deleting Horse', error);
          this.bannerError = 'Could not delete Horse: ' + error.message;
        }
      });
  }


  ownerName(owner: Owner | null): string {
    return owner
      ? `${owner.firstName} ${owner.lastName}`
      : 'None';
  }

  dateOfBirthAsLocaleDate(horse: Horse): string {
    return new Date(horse.dateOfBirth).toLocaleDateString();
  }

}
