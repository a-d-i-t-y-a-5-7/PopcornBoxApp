import { Injectable } from '@angular/core';
import{ HttpClient } from '@angular/common/http'
import{ Media } from './media';
import { Song } from '../models/song';

@Injectable({
  providedIn: 'root'
})
export class MediaService {

  constructor(private http:HttpClient) { }
  getById(id: number) {
    return this.http.get<Media>(`https://localhost:7059/api/Media/${id}`);
   }

   get(){
    return this.http.get<Media[]>('https://localhost:7059/api/Media');
  }

  getSongById(id: number) {
    return this.http.get<Song>(`https://localhost:7059/api/Client/getsongbyid/${id}`);
   }
}
