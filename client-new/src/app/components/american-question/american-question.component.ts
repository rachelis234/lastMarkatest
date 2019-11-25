import { Component, OnInit, Input } from '@angular/core';
import { Question } from 'src/app/Models/Question';
import { Answer } from 'src/app/Models/Answer';
import { UserService } from 'src/app/services/user.service';
import { MatRadioButton } from '@angular/material';

@Component({

  selector: 'app-american-question',
  templateUrl: './american-question.component.html',
  styleUrls: ['./american-question.component.scss']
})

export class AmericanQuestionComponent implements OnInit {
  @Input() ques: Question;
  answers: Answer[];
  //newSelected: Answer;
  // favoriteSeason: string;
  // seasons: string[] = ['Winter', 'Spring', 'Summer', 'Autumn'];
  constructor(private userService: UserService) { }

  ngOnInit() {
   

    this.answers = this.userService.solveTest.answers.filter(a => a.question_id == this.ques.question_id);
    
    
    
  }
  onSelectedAnswer(event:MatRadioButton)
  {
    for(let i of this.userService.solveTest.selectedAnswer)
    {
      if(i.question_id==event.value.question_id)
      {
this.userService.solveTest.selectedAnswer.splice(this.userService.solveTest.selectedAnswer.indexOf(i),1);
      }
    }
 
 this.userService.solveTest.selectedAnswer.push(event.value);


  }

}
