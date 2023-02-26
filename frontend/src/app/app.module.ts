import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {ToastrModule} from 'ngx-toastr';
import {MatDialogModule} from '@angular/material/dialog'; 


import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {AutocompleteComponent} from './component/autocomplete/autocomplete.component';
import {HeaderComponent} from './component/header/header.component';
import {HorseCreateEditComponent} from './component/horse/horse-create-edit/horse-create-edit.component';
import {HorseComponent} from './component/horse/horse.component';
import {OwnerComponent } from './component/owner/owner.component';
import {OwnerCreateEditComponent } from './component/owner/owner-create-edit/owner-create-edit.component';
import {ConfirmationDeleteDialogComponent} from './component/confirm-delete-dialog/confirmation-delete-dialog';
import { DetailDialogComponent } from './component/detail-dialog/detail-dialog.component';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HorseComponent,
    HorseCreateEditComponent,
    AutocompleteComponent,
    OwnerComponent,
    OwnerCreateEditComponent,
    ConfirmationDeleteDialogComponent,
    DetailDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    ToastrModule.forRoot(),
    // Needed for Toastr
    BrowserAnimationsModule,
    MatDialogModule
  ],
  providers: [
    
  ],
  entryComponents:[ConfirmationDeleteDialogComponent],
  bootstrap: [AppComponent]
})
export class AppModule {
}
