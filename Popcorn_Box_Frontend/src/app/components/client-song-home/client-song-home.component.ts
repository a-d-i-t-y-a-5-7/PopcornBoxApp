import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Song } from 'src/app/models/song';
import { ClientServiceService } from 'src/app/services/client-service.service';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-client-song-home',
  templateUrl: './client-song-home.component.html',
  styleUrls: ['./client-song-home.component.css']
})
export class ClientSongHomeComponent implements OnInit {
  allSongs: Song[] = [];

  constructor(private clientService: ClientServiceService, private router: Router, private route: ActivatedRoute, private userService:UserServiceService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      this.get(this.userService.GetUserId());
    });
  }

  dataSource: any;

  get(id: number) {
    this.clientService.getSongs(id).subscribe((data) => {
      this.allSongs = data
      this.dataSource = new MatTableDataSource(this.allSongs)
      console.log('list of media', this.allSongs)
    })
  }

  delete(id: number) {
    this.clientService.deleteSongs(id)
      .subscribe({
        next: (data) => {
          window.location.reload();
          this.router.navigate(["my-song"]);
        },
        error: (err) => {
          console.log(err);
        }
      })
  }

  displayedColumns: string[] = ['id', 'name', 'singers', 'play', 'edit', 'delete'];

}
