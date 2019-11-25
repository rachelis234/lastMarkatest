import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student } from 'src/app/Models/Student';
import { ApiService } from 'src/app/services/api.service';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-view-students',
  templateUrl: './view-students.component.html',
  styleUrls: ['./view-students.component.css']
})
export class ViewStudentsComponent implements OnInit {
  id:number;
  // displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);

  // applyFilter(filterValue: string) {
  //   this.dataSource.filter = filterValue.trim().toLowerCase();
  // }
  constructor(private router: ActivatedRoute, private apiService: ApiService) {
    this.router.params.subscribe(data => {
      this.id = +data['class_id'];
      this.apiService.getStudentsForClass(this.id).subscribe(
        (res: Student[]) => this.apiService.studentsForClass = res,
        (err) => console.log(err)
      );
    });
  }

  ngOnInit() {
  }
  deleteStudent(studentId:number){
    this.apiService.deleteStudent(studentId).subscribe(
      (res)=>{
        this.apiService.studentsForClass = this.apiService.studentsForClass.filter(item => item.userId !== studentId);
        new alert("deleted!!!");
      }
        ,
      (err)=>console.log(err)
    );
  }
}
