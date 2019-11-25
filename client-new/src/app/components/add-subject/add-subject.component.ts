import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/Models/Category';
import { UserService } from 'src/app/services/user.service';
import { Teacher } from 'src/app/Models/Teacher';
import { ApiService } from 'src/app/services/api.service';


@Component({
  selector: 'app-add-subject',
  templateUrl: './add-subject.component.html',
  styleUrls: ['./add-subject.component.css']
})
export class AddSubjectComponent implements OnInit {
  subject:Category=new Category();
  // teacher:Teacher;
  constructor(private router:ActivatedRoute,private userService:UserService,private apiService:ApiService) { 
    this.userService.getCategoriesForTeacher().subscribe(
      (res:Category[])=>this.userService.categoriesForTeacher=res,
      (err)=>console.log(err)
    );
  }

  ngOnInit() {
  }
  addSubject(subjectName:string){
    this.subject.category_name=subjectName;
    // this.teacher=this.userService.user as Teacher;
    this.subject.teacher_id=(this.userService.user as Teacher).teacherId;
    console.log(this.subject.teacher_id);
    this.apiService.addCategory(this.subject).subscribe(
      (res:Category)=>this.userService.categoriesForTeacher.push(res),
      (err)=>console.log(err));
  }

}
