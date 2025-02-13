import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Song } from '../models/song';
import { IFavouriteSong } from '../models/IFavouriteSong';

@Injectable({
  providedIn: 'root'
})
export class FavouriteSongService {

  constructor(private http : HttpClient) { }

  GetFavouriteSong(id:number){
    return this.http.get<Song[]>('https://localhost:7059/user/favouriteSong/myFavSong/'+id);
  }

  RemoveFavourite(favSong:IFavouriteSong){
    return this.http.post<IFavouriteSong>('https://localhost:7059/user/favouriteSong/remove',favSong);
  }

  AddFavouriteSong(favSong:IFavouriteSong){
    return this.http.post<IFavouriteSong>('https://localhost:7059/user/favourite/song',favSong);
  }
}
