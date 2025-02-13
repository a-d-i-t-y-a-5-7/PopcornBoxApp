import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IFavouriteSong } from 'src/app/models/IFavouriteSong';
import { Song } from 'src/app/models/song';
import { FavouriteSongService } from 'src/app/services/favourite-song.service';
import { SongService } from 'src/app/services/song.service';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.css']
})
export class SongComponent {

  constructor(private songService: SongService, private router: Router, private userService: UserServiceService, private favSongService: FavouriteSongService) { }

  mySong: Song[] = [];
  myFavSong: Song[] = [];

  favSong: IFavouriteSong = {
    UserId: 0,
    SongId: 0
  }



  ngOnInit(): void {
    this.getSong();
    this.GetFavouriteSong(this.userService.GetUserId());
  }

  getSong() {
    this.songService.GetSong().
      subscribe(response => {
        this.mySong = response;
        console.log(response);
      })
  }

  GetFavouriteSong(id: number) {
    this.favSongService.GetFavouriteSong(id).subscribe({
      next: (response => {
        this.myFavSong = response;
      })
    })
  }

  IsFavouriteSong(id: number): boolean {
    for (const element of this.myFavSong) {
      if (element.songsId == id) {
        return true;
      }
    }
    return false;
  }

  deleteFavSong(id: number) {
    this.favSong.SongId = id;
    this.favSong.UserId = this.userService.GetUserId();
    this.favSongService.RemoveFavourite(this.favSong).subscribe({
      next:(response => {
        this.ngOnInit();
      })
    })
  }
  AddFavSong(id: number) {
    this.favSong.SongId = id;
    this.favSong.UserId = this.userService.GetUserId();
    this.favSongService.AddFavouriteSong(this.favSong).subscribe({
      next:(response => {
        this.ngOnInit();
      })
    })
  }

  searchText : string = '';

  onSearchTextEntered(searchValue:string){
    this.searchText = searchValue;
    console.log(this.searchText);
    
  }

  PlayMedia(id:number){
    this.router.navigate(['/media/song-player',id]);
  }
}
