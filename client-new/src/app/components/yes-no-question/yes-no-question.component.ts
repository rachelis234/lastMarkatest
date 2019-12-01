import { Component, OnInit,Input } from '@angular/core';
import { Question } from 'src/app/Models/Question';
import { Answer } from 'src/app/Models/Answer';
import { UserService } from 'src/app/services/user.service';
import { MatRadioChange } from '@angular/material';
@Component({
  selector: 'app-yes-no-question',
  templateUrl: './yes-no-question.component.html',
  styleUrls: ['./yes-no-question.component.scss']
})
export class YesNoQuestionComponent implements OnInit {
  @Input() ques:Question;
  answers:Answer[];
  
  
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.answers = this.userService.solveTest.answers.filter(a => a.question_id == this.ques.question_id);
  }
  onSelectedAnswer(event:MatRadioChange)
  {
    for(let i of this.userService.solveTest.selectedAnswer)
    {
      if(i.question_id==event.value.question_id)
      {
this.userService.solveTest.selectedAnswer.splice(this.userService.solveTest.selectedAnswer.indexOf(i),1);
      }
    }
    this.userService.solveTest.selectedAnswer.push(event.value);
 console.log(this.userService.solveTest.selectedAnswer);
}
}