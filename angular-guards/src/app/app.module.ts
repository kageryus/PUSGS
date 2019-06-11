import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { ReactiveFormsModule , FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent }            from './app.component';
import { PageNotFoundComponent }   from './page-not-found/page-not-found.component';

import { AppRoutingModule }        from './app-routing.module';
import { AdminComponent } from './admin/admin.component';
import { LoginComponent } from './auth/login/login.component';

import { CrisisCenterComponent } from './crisis-center/crisis-center/crisis-center.component';
import { CrisisCenterHomeComponent } from './crisis-center/crisis-center-home/crisis-center-home.component';
import { CrisisDetailComponent } from './crisis-center/crisis-detail/crisis-detail.component';
import { CrisisListComponent } from './crisis-center/crisis-list/crisis-list.component';
import { RegistrationComponent } from './registration/registration.component';

import { IndexComponent } from './index/index.component';
import { LineComponent } from './line/line.component';
import { LocationComponent } from './location/location.component';
import { PricelistComponent } from './pricelist/pricelist.component';
import { StationComponent } from './station/station.component';
import { StufComponent } from './stuf/stuf.component';
import { TimetableComponent } from './timetable/timetable.component';
import { KupiKartuComponent } from './kupi-kartu/kupi-kartu.component';
import { MapComponent } from './map/map.component';
import { AgmCoreModule } from '@agm/core';


@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent,
    AdminComponent,
    LoginComponent,
    RegistrationComponent,
    CrisisCenterComponent,
    CrisisCenterHomeComponent,
    CrisisListComponent,
    CrisisDetailComponent,
    RegistrationComponent,
    IndexComponent,
    LineComponent,
    LocationComponent,
    PricelistComponent,
    StationComponent,
    StufComponent,
    TimetableComponent,
    KupiKartuComponent,
    MapComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    AgmCoreModule.forRoot({apiKey: 'AIzaSyDnihJyw_34z5S1KZXp90pfTGAqhFszNJk'})

  ],
  providers: [],
  bootstrap: [ AppComponent ]
})
export class AppModule {}
