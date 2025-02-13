import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Song } from '../models/song';

@Injectable({
  providedIn: 'root'
})
export class SongService {

  constructor(private http:HttpClient) { }

  GetSong(){
    return this.http.get<Song[]>('https://localhost:7059/api/Media/songs');
  }
}
