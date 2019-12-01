import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from 'src/app/Models/Student';
import { ApiService } from 'src/app/services/api.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent implements OnInit {

  studentId:number;
  student:Student;
  index:number;
  marks;
  constructor(private router:ActivatedRoute,private apiService:ApiService,private route:Router, private userService:UserService) {
    this.router.params.subscribe(data => {
      this.studentId = +data['studentId'];
    });
    this.student=this.apiService.studentsForClass.find(s=>s.userId==this.studentId);
    this.index = this.apiService.studentsForClass.indexOf(this.student);
   }

  ngOnInit() {
    this.userService.getStudentMarks(this.studentId,this.userService.user.teacherId ).subscribe(res=>{
      debugger
this.marks=res;
    })
  }
  editStudent(){
    this.apiService.editStudent(this.student).subscribe(
      (res:Student)=>{
        this.apiService.studentsForClass[this.index]=res;
        this.route.navigate(['/teachersettings/viewClasses/viewStudents/',this.student.class_id]);
      },
      (err)=>console.log(err)
    );
  }
}
