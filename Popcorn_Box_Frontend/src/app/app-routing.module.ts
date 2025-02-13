import { NgModule } from '@angular/core';
import { Routes } from '@angular/router';
import { RouterModule } from '@angular/router';
import { PlayerComponent } from './media/player/player.component';
import { HomeComponent } from './components/home/home.component';
import { MoviesComponent } from './components/movies/movies.component';
import { RegisterComponent } from './components/register/register.component';
import { ClientHomeComponent } from './components/client-home/client-home.component';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { authGuard } from './shared/auth.guard';
import { roleGuard } from './shared/role.guard';
import { ClientCreateComponent } from './components/client-create/client-create.component';
import { TvshowsComponent } from './components/tvshows/tvshows.component';
import { ClientEditComponent } from './components/client-edit/client-edit.component';
import { FavouriteMediaComponent } from './components/favourite-media/favourite-media.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { ClientSongHomeComponent } from './components/client-song-home/client-song-home.component';
import { ClientSongCreateComponent } from './components/client-song-create/client-song-create.component';
import { ClientSongEditComponent } from './components/client-song-edit/client-song-edit.component';
import { ClientApprovalComponent } from './components/client-approval/client-approval.component';
import { SongComponent } from './components/song/song.component';
import { expiryGuard } from './shared/expiry.guard';
import { clientGuard } from './shared/client.guard';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'player', component: PlayerComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'my-media/:id', component: ClientHomeComponent, canActivate:[authGuard,clientGuard,expiryGuard]},
  { path: 'movies', component: MoviesComponent },
  { path: 'login', component: LoginComponent },
  { path: 'profile/:id', component: ProfileComponent, canActivate: [authGuard,expiryGuard] },
  { path: 'add-media', component: ClientCreateComponent, canActivate:[authGuard,clientGuard,expiryGuard]},
  { path: 'tvshows', component: TvshowsComponent },
  { path: 'edit-media/:id', component: ClientEditComponent,canActivate:[authGuard,clientGuard,expiryGuard] },
  { path: 'favouriteMedia/:id', component: FavouriteMediaComponent, canActivate: [authGuard,expiryGuard] },
  { path: 'user-list', component: UserListComponent ,canActivate:[authGuard,roleGuard,expiryGuard]},
  { path: 'my-song/:id', component: ClientSongHomeComponent,canActivate:[authGuard,clientGuard,expiryGuard]},
  { path: 'add-song', component: ClientSongCreateComponent,canActivate:[authGuard,clientGuard,expiryGuard]},
  { path: 'edit-song/:id', component: ClientSongEditComponent,canActivate:[authGuard,clientGuard,expiryGuard]},
  { path: 'client-approval', component:ClientApprovalComponent ,canActivate:[authGuard,roleGuard,expiryGuard]},
  { path: 'song', component:SongComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }