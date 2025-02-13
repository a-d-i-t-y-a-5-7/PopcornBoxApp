import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MediaModule } from './media/media.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { GalleryModule } from 'ng-gallery';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { MoviesComponent } from './components/movies/movies.component';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RegisterComponent } from './components/register/register.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatRadioModule } from '@angular/material/radio';
import { MatNativeDateModule } from '@angular/material/core';
import { ClientHomeComponent } from './components/client-home/client-home.component';
import { MatTableModule } from '@angular/material/table'
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatMenuModule } from '@angular/material/menu';
import { LoginComponent } from './components/login/login.component';
import { ValidateInterceptor } from './Interceptor/validate.interceptor';
import { ProfileComponent } from './components/profile/profile.component';
import { ClientCreateComponent } from './components/client-create/client-create.component';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { NgxSpinnerModule } from 'ngx-spinner';
import { TvshowsComponent } from './components/tvshows/tvshows.component';
import { SectionSplitComponent } from './components/section-split/section-split.component';
import { CardComponent } from './components/card/card.component';
import { ClientApprovalComponent } from './components/client-approval/client-approval.component';
import { UserListComponent } from './components/user-list/user-list.component';
import {MatPaginatorModule} from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { SongComponent } from './components/song/song.component';
import { ClientEditComponent } from './components/client-edit/client-edit.component';
import { FavouriteMediaComponent } from './components/favourite-media/favourite-media.component';
import { FooterComponent } from './components/footer/footer.component';
import { NgImageSliderModule } from 'ng-image-slider';
import { ClientSongHomeComponent } from './components/client-song-home/client-song-home.component';
import { ClientSongCreateComponent } from './components/client-song-create/client-song-create.component';
import { ClientSongEditComponent } from './components/client-song-edit/client-song-edit.component';
import { SearchComponent } from './components/search/search.component';
import { GuidedTourModule, GuidedTourService } from 'ngx-guided-tour';
import { GlobalErrorHandler } from './basic-error-handler';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    RegisterComponent,
    ClientHomeComponent,
    MoviesComponent,
    LoginComponent,
    ProfileComponent,
    ClientCreateComponent,
    TvshowsComponent,
    SectionSplitComponent,
    CardComponent,
    ClientApprovalComponent,
    UserListComponent,
    SongComponent,
    ClientEditComponent,
    FavouriteMediaComponent,
    FooterComponent,
    ClientSongHomeComponent,
    ClientSongCreateComponent,
    ClientSongEditComponent,
    SearchComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MediaModule,
    HttpClientModule,
    FormsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatSidenavModule,
    MatListModule,
    GalleryModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    MatCardModule,
    MatDatepickerModule,
    MatRadioModule,
    MatNativeDateModule,
    MatTableModule,
    MatInputModule,
    MatSelectModule,
    MatMenuModule,
    InfiniteScrollModule,
    NgxSpinnerModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    NgImageSliderModule,
    GuidedTourModule,
    
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ValidateInterceptor, multi: true },
    GuidedTourService,
    { provide: ErrorHandler, useClass: GlobalErrorHandler}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
