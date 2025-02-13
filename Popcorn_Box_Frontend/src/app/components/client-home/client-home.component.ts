import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientServiceService } from 'src/app/services/client-service.service';
import { Media } from 'src/app/media/media';
import { UserServiceService } from 'src/app/services/user-service.service';


@Component({
  selector: 'app-client-home',
  templateUrl: './client-home.component.html',
  styleUrls: ['./client-home.component.css'],

})
export class ClientHomeComponent implements OnInit {

  allMedia: Media[] = [];
  constructor(private clientService: ClientServiceService, private router: Router, private route: ActivatedRoute,private userService:UserServiceService) { }
  ngOnInit(): void {
    this.route.paramMap.subscribe((param) => {
      // var id = Number(param.get('id'));
      this.get(this.userService.GetUserId());
    });
  }
  dataSource: any;
  get(id: number) {
    this.clientService.get(id).subscribe((data) => {
      this.allMedia = data
      this.dataSource = new MatTableDataSource(this.allMedia)
      console.log('list of media', this.allMedia)
    })
  }

  delete(id: number) {
    this.clientService.delete(id)
      .subscribe({
        next: (data) => {
          window.location.reload();
          this.router.navigate(["my-media"]);
        },
        error: (err) => {
          console.log(err);
        }
      })
  }
  displayedColumns: string[] = ['id', 'name', 'actors', 'play', 'edit', 'delete'];


}
