import { Inject, OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FavouriteMediaServicesService } from 'src/app/services/favourite-media-services.service';
import { Section } from '../section-split/section';
import { Media } from 'src/app/models/media';
import { MediaService } from 'src/app/services/media.service';
import { IFavouriteMedia } from 'src/app/models/IFavouriteMedia';
import { Song } from 'src/app/models/song';
import { FavouriteSongService } from 'src/app/services/favourite-song.service';
import { IFavouriteSong } from 'src/app/models/IFavouriteSong';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-favourite-media',
  templateUrl: './favourite-media.component.html',
  styleUrls: ['./favourite-media.component.css']
})
export class FavouriteMediaComponent implements OnInit {
  public sectionItem: Section[] = [];
  fMedia: Media[] = [];
  fSong:Song[] = [];
  media : Media[] = [];
  favouriteMediaObj : IFavouriteMedia = {
    UserId:0,
    MediaId:0
  }

  favouriteSongObj:IFavouriteSong={
    UserId : 0,
    SongId : 0
  }
  userId : number = 0;
  constructor(private favMedService: FavouriteMediaServicesService, private router: ActivatedRoute,public mediaService : MediaService,private favSongService : FavouriteSongService, private route:Router, private userService:UserServiceService) { }
  ngOnInit(): void {
    this.router.paramMap.subscribe((param) => {
      this.userId = this.userService.GetUserId();
      this.getFavMedById(this.userId);
      this.getFavSongById(this.userId);
    });
  }
  getFavMedById(id: number) {
    this.favMedService.GetFavouriteMedia(id).subscribe({
      next: (response => {
        this.fMedia = response;
      })
    })
  }

  getFavSongById(id:number){
    this.favSongService.GetFavouriteSong(id).subscribe({
      next:(response => {
        this.fSong = response;
      })
    })
  }
  IsFavourite(id:number):boolean{
    for(const element of this.fMedia){
      if(element.id==id){
        return true;
      }
    }
    return false;
  }

  IsFavouriteSong(id:number):boolean{
    for (const element of this.fSong) {
      if (element.songsId == id) {
        return true;
      }
    }
    return false;
  }

  deleteFavourite(id:number){
    this.favouriteMediaObj.MediaId = id;
    this.favouriteMediaObj.UserId = this.userId;
    this.favMedService.RemoveFavourites(this.favouriteMediaObj).subscribe({
      next:(resposne=>{
        console.log(resposne);
        this.ngOnInit();
      })
    });
  }

  deleteFavouriteSong(id:number){
    this.favouriteSongObj.SongId = id;
    this.favouriteSongObj.UserId = this.userId;
    this.favSongService.RemoveFavourite(this.favouriteSongObj).subscribe({
      next:(response => {
        this.ngOnInit();
      })
    })
  }

  PlaySong(id:number){
    this.route.navigate(['/media/song-player',id]);
  }

  PlayMedia(id:number){
    this.route.navigate(['/media/player',id]);
  }
}
