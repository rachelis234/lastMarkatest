import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Question } from 'src/app/Models/Question';
import { Sub_category } from 'src/app/Models/Sub_category';
import { ApiService } from 'src/app/services/api.service';
import { UserService } from 'src/app/services/user.service';
import { Class } from 'src/app/Models/Class';
import { Teacher } from 'src/app/Models/Teacher';
import { Category } from 'src/app/Models/Category';
import { Type } from 'src/app/Models/Type';
import { WebResult } from 'src/app/Models/WebResult';

@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.css']
})
export class AddQuestionComponent implements OnInit {
  // nodes;
  // options = {};
  // @Output() nodeClicked:EventEmitter<any>=new EventEmitter<any>();
  question:Question=new Question();
  categoryId:number;
  subCategoriesForCat:Sub_category[]=null;
  constructor(private apiService:ApiService,private userService:UserService) {
    this.question.question_id=0;
    this.userService.getCategoriesForTeacher().subscribe(
      (res:any) => {
        debugger;
        this.userService.categoriesForTeacher = res.value;
        console.log(this.userService.categoriesForTeacher);
      },
      (err) => console.log(err)
    );
    // this.userService.get
  }
  ngOnInit() {
  }
  getSubCategoriesForCat() {
    this.apiService.getSubCategoriesForCat(this.categoryId).subscribe(
      (res: Sub_category[]) => { this.apiService.subCategoriesForCat = res, console.log(res) },
      (err) => console.log(err)
    );
  }
  addQuestion() {
    this.apiService.addQuestion(this.question).subscribe(
      (res: Question) => {
        var i: any;
        for (i in this.userService.questionsForTeacher) {
          if ((i as Question[])[0].sub_category_id == res.sub_category_id) {
            i.push(res);
            break;
          }
        }
        // this.userService.questionsForTeacher.push(res);
      },
      (err) => console.log(err)
    );
  }
  // nodeClick(node){
  //   this.nodeClicked.emit(node);
  // }

}
