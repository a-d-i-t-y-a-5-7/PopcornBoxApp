import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MediaRoutingModule } from './media-routing.module';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { PlayerComponent } from './player/player.component';
import { VgCoreModule } from '@videogular/ngx-videogular/core';
import { VgControlsModule } from '@videogular/ngx-videogular/controls';
import { VgOverlayPlayModule } from '@videogular/ngx-videogular/overlay-play';
import { VgBufferingModule } from '@videogular/ngx-videogular/buffering';
import { SongPlayerComponent } from './song-player/song-player.component';
import { GuidedTourModule} from 'ngx-guided-tour';


@NgModule({
  declarations: [
    HomeComponent,
    PlayerComponent,
    SongPlayerComponent,
    
  ],
  imports: [
    CommonModule,
    MediaRoutingModule,
    FormsModule,
    VgCoreModule,
    VgControlsModule,
    VgOverlayPlayModule,
    VgBufferingModule,
    GuidedTourModule
  ]
})
export class MediaModule { }
