import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { Question } from "src/app/Models/Question";
import { Sub_category } from "src/app/Models/Sub_category";
import { ApiService } from "src/app/services/api.service";
import { UserService } from "src/app/services/user.service";
import { Class } from "src/app/Models/Class";
import { Teacher } from "src/app/Models/Teacher";
import { Category } from "src/app/Models/Category";
import { Type } from "src/app/Models/Type";
import { WebResult } from "src/app/Models/WebResult";
import { Answer } from "src/app/Models/Answer";
import { FormBuilder, FormGroup, FormArray, FormControl } from "@angular/forms";

@Component({
  selector: "app-add-question",
  templateUrl: "./add-question.component.html",
  styleUrls: ["./add-question.component.css"]
})
export class AddQuestionComponent implements OnInit {
  // nodes;
  // options = {};
  // @Output() nodeClicked:EventEmitter<any>=new EventEmitter<any>();
  question: Question = new Question();
  categoryId: number;
  answers: Answer[] = [];
  answerForm: FormGroup;
  constructor(
    private apiService: ApiService,
    private userService: UserService,
    private fb: FormBuilder
  ) {
    this.question.question_id = 0;
    this.question.type_id = 0;
    this.userService.getCategoriesForTeacher().subscribe(
      (res: any) => {
        this.userService.categoriesForTeacher = res.value;
        console.log(this.userService.categoriesForTeacher);
      },
      err => console.log(err)
    );
    // this.userService.get
  }
  ngOnInit() {
    this.answerForm = this.fb.group({
      title: [],
      answers_array: this.fb.array([this.fb.group({ ans: "" })])
    });
    this.apiService.getTypes().subscribe(
      (res: Type[]) => {
        // debugger;
        this.apiService.types = res;
        console.log(this.apiService.types);
        // debugger;
      },
      err => console.log(err)
    );
  }
  getSubCategoriesForCat() {
    this.apiService.getSubCategoriesForCat(this.categoryId).subscribe(
      (res: WebResult) => {
        (this.apiService.subCategoriesForCat = res.value as Sub_category[]),
          console.log(res);
      },
      err => console.log(err)
    );
  }
  addQuestion() {
    var j: any;
    var ans = new Answer();
    console.log(this.answerForm.value.title);
    console.log(this.answers_array);
    console.log(this.answers_array.controls);
    console.log(this.answers_array.controls[0].value.ans);
    console.log(this.answers_array.controls[1].value.ans);

    ans.answer_text = this.answers_array.controls[0].value.ans;
    ans.answer_id = 0;
    ans.question_id = 0;
    ans.isCorrect = true;
    console.log(ans);
    this.answers.push(ans);
    ans = new Answer();
    ans.answer_text = this.answers_array.controls[1].value.ans;
    ans.answer_id = 0;
    ans.question_id = 0;
    ans.isCorrect = false;
    this.answers.push(ans);
    ans = new Answer();
    ans.answer_text = this.answers_array.controls[2].value.ans;
    ans.answer_id = 0;
    ans.question_id = 0;
    ans.isCorrect = false;
    this.answers.push(ans);

    // for (j in this.answers_array.controls) {
    //   ans = new Answer();
    //   ans.answer_text = (j as FormGroup).value.ans;
    //   ans.answer_id = 0;
    //   ans.question_id = 0;
    //   console.log(ans);
    //   this.answers.push(ans);
    // }
    this.apiService.addQuestion(this.question, this.answers).subscribe(
      (res: WebResult) => {
        var i: any;
        for (i in this.userService.questionsForTeacher) {
          if (
            (i as Question[])[0].sub_category_id ==
            (res.value as Question).sub_category_id
          ) {
            i.push(res.value as Question);
            break;
          }
        }
        // this.userService.questionsForTeacher.push(res);
      },
      err => console.log(err)
    );
  }
  // nodeClick(node){
  //   this.nodeClicked.emit(node);
  // }
  get answers_array() {
    return this.answerForm.get("answers_array") as FormArray;
  }
  addAnswer() {
    this.answers_array.push(this.fb.group({ ans: "" }));
    console.log(this.answers_array);
  }

  deleteAnswer(index) {
    this.answers_array.removeAt(index);
  }
}
