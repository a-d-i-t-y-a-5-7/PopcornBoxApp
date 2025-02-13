import { NgModule } from '@angular/core';
import { Routes } from '@angular/router';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PlayerComponent } from './player/player.component';
import { SongPlayerComponent } from './song-player/song-player.component';

const routes: Routes = [
  { path: 'media/home', component: HomeComponent },
  { path: 'media/player/:id', component: PlayerComponent },
  { path: 'media/song-player/:id', component: SongPlayerComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MediaRoutingModule { }
