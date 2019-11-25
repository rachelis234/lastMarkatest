import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { WebResult } from 'src/app/Models/WebResult';
import { SolveTest } from 'src/app/Models/SolveTest';
import { Question } from 'src/app/Models/Question';
import { Answer } from 'src/app/Models/Answer';

@Component({
  selector: 'app-solve-test',
  templateUrl: './solve-test.component.html',
  styleUrls: ['./solve-test.component.css']
})
export class SolveTestComponent implements OnInit {
sortedQuestion:Array<Question[]>;

  constructor(private userService: UserService, private router: Router) {}

  ngOnInit() {
    this.sortedQuestion=new Array();
    console.log(this.sortedQuestion.length);
this.sortedQuestion.push(new Array<Question>());
this.sortedQuestion.push(new Array<Question>());
this.sortedQuestion.push(new Array<Question>());

console.log(this.sortedQuestion.length);
    this.userService.getTest(this.userService.user.userId,Date.now()).subscribe(
      (res: WebResult) => {
        if(res.status==true)
        {
          
          this.userService.solveTest=res.value as SolveTest;
          
          this.userService.solveTest.selectedAnswer=new Array<Answer>();
          
          this.userService.solveTest.questions.forEach(q => {
            this.sortedQuestion[q.type_id-1].push(q);
          });

          
        }
        else
        console.log(res.message);
        },
        (err) => console.log(err));

  }

}
