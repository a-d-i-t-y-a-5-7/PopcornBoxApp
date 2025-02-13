import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Media } from '../models/media';
import { Song } from '../models/song';

@Injectable({
  providedIn: 'root'
})
export class MediaService {

  constructor(private http:HttpClient) { }

  url:string = 'https://localhost:7059';

  get(id: number) {
    return this.http.get<Media[]>(this.url+`/api/Media/mediaType/${id}`);
  }

  getMedia(id: number){
    return this.http.get<Media[]>(this.url+`/api/Media/mediaType/${id}`);
  }

  getMediaByGenre(id: number) {
    return this.http.get<Media[]>(this.url+`/api/Media/filterbyGenre/${id}`);
  }

  getSongMedia(){
    return this.http.get<Song[]>(this.url+'/api/Media/songs');
  }

  getMediaDetails(){
    return this.http.get<Media[]>(this.url+'/api/Media');
  }
}
