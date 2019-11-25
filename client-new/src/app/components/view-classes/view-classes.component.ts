import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Class } from 'src/app/Models/Class';
import { Teacher } from 'src/app/Models/Teacher';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-view-classes',
  templateUrl: './view-classes.component.html',
  styleUrls: ['./view-classes.component.css']
})
export class ViewClassesComponent implements OnInit {
  classId: number;
  //displayedColumns: string[] = ['class_name', 'level'];
  //dataSource = new MatTableDataSource<Class>(this.userService.classesForTeacher);
  // elem: Class[] ;
  // dataSource = new MatTableDataSource<Class>(this.elem);
  // @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

  constructor(private userService: UserService, private router: Router) {
    this.userService.getClassesForTeacher().subscribe(
      (res: Class[]) => { 
        this.userService.classesForTeacher = res;
       },
      (err) => console.log(err)
    );
    //this.elem=this.userService.classesForTeacher;
  }

  ngOnInit() {

    //this.dataSource.paginator = this.paginator;
  }


  //   navigate(id){
  // this.router.navigate(['/teachersettings/viewClasses/viewStudents/'+id]);
  //   }

}

