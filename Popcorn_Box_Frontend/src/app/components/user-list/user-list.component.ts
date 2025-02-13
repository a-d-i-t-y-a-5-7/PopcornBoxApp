import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  
  displayedColumns = ['name','email','contact','isActive'];
  dataSource!:MatTableDataSource<any>;
  @ViewChild('paginator') paginator! : MatPaginator;
  @ViewChild(MatSort) matSort! : MatSort;
  constructor(private service: AdminService, private router:Router){}

  ngOnInit(){
    this.getUser(2);
  }

  getUser(id: number) {
    this.service.getUser(id).subscribe(
      response => {
        console.log(response);
        this.dataSource = new MatTableDataSource(response);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.matSort;
      })
  }

  delete(id:number){
    this.service.deleteUser(id)
    .subscribe({
      next:(data) => {
        this.getUser(2); 
      },
      error:(err) => {
        console.log(err);
      }
    })
  }

  filterData($event : any){
    this.dataSource.filter = $event.target.value;
  }
}

