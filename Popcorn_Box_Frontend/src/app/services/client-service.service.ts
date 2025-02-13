import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Media } from '../media/media';
import { ClientMedia } from '../models/clientmedia';
import { ClientSong } from '../models/clientSong';
import { Song } from '../models/song';

@Injectable({
  providedIn: 'root'
})
export class ClientServiceService {

  constructor(private http:HttpClient) { }
  getById(id: number) {
    return this.http.get<Media>(`https://localhost:7059/api/Client/getmediabyid/${id}`);
   }

   get(id:number){
    return this.http.get<Media[]>(`https://localhost:7059/api/Client/medialist/${id}`);
  }

  delete(id: number){
    return this.http.delete(`https://localhost:7059/api/Client/${id}`);
   }

   post(payload:ClientMedia){
    return this.http.post<ClientMedia[]>('https://localhost:7059/api/Client/addmedia',payload);
  }

  update(payload:Media){
    return this.http.put(`https://localhost:7059/api/Client/updatemedia/${payload.id}`,payload);
   }

   getSongs(id:any){
    return this.http.get<Song[]>(`https://localhost:7059/api/Client/songlist/${id}`);
  }

  deleteSongs(id: number){
    return this.http.delete(`https://localhost:7059/api/Client/deletesong/${id}`);
   }

   postSongs(payload:ClientSong){
    return this.http.post<ClientSong[]>('https://localhost:7059/api/Client/addsong',payload);
  }

  getSongById(id: number) {
    return this.http.get<Song>(`https://localhost:7059/api/Client/getsongbyid/${id}`);
   }

   updateSong(payload:Song){
    return this.http.put(`https://localhost:7059/api/Client/updatesong/${payload.songsId}`,payload);
   }
}
