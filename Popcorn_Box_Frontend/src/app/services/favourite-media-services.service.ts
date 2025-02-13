import{ HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Media } from '../media/media';
import { IFavouriteMedia } from '../models/IFavouriteMedia';

@Injectable({
  providedIn: 'root'
})
export class FavouriteMediaServicesService {

  constructor(private http : HttpClient) { }

  GetFavouriteMedia(userId:number){
    return this.http.get<Media[]>('https://localhost:7059/User/favouriteMedia/myFavs/'+userId);
  }
  RemoveFavourites(favouriteMediaObject:IFavouriteMedia){
    return this.http.post<IFavouriteMedia>('https://localhost:7059/User/favouriteMedia/remove',favouriteMediaObject);
  }
  AddFavouriteMedia(favouriteMediaObj:IFavouriteMedia){
    return this.http.post<IFavouriteMedia>('https://localhost:7059/User/favouriteMedia/add',favouriteMediaObj);
  }
}
