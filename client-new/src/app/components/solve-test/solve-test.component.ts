import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { WebResult } from 'src/app/Models/WebResult';
import { SolveTest } from 'src/app/Models/SolveTest';
import { Question } from 'src/app/Models/Question';
import { Answer } from 'src/app/Models/Answer';
import { studentMark } from 'src/app/Models/StudentMark';

@Component({
  selector: 'app-solve-test',
  templateUrl: './solve-test.component.html',
  styleUrls: ['./solve-test.component.css']
})
export class SolveTestComponent implements OnInit {
sortedQuestion:Array<Question[]>;
endTime;
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit() {
    this.sortedQuestion=new Array();
    console.log(this.sortedQuestion.length);
this.sortedQuestion.push(new Array<Question>());
this.sortedQuestion.push(new Array<Question>());
this.sortedQuestion.push(new Array<Question>());
console.log(this.sortedQuestion.length);

var date = new Date(); 


var ticks = ((date.getTime() * 10000) + 621355968000000000) - (date.getTimezoneOffset() * 600000000);
    this.userService.getTest(this.userService.user.userId,ticks).subscribe(
      (res: WebResult) => {
        if(res.status==true)
        {
          this.userService.solveTest=res.value as SolveTest;
          
          this.userService.solveTest.selectedAnswer=new Array<Answer>();
          this.endTime=this.userService.solveTest.test.test_end_time;
          this.userService.solveTest.questions.forEach(q => {
            this.sortedQuestion[q.type_id-1].push(q);

          });

          
        }
        else
        console.log(res.message);
        },
        (err) => console.log(err));
  }

  t= setTimeout(() => {
    var d= new Date();
    if(d.getHours()>this.endTime.split(":")[0] ||(d.getHours()==this.endTime.split(":")[0]&&d.getMinutes()==this.endTime.split(":")[1])){
        alert("youtTimeEnd");
    this.checkTest(); 
    }
 
  
  }, 1000);
 checkTest() {
  var point=100/this.userService.solveTest.selectedAnswer.length;
  var mark=0;
this.userService.solveTest.selectedAnswer.forEach(ans=>{
  if(ans['qusid']!=undefined)
  {
    if(ans.question_id==ans['qusid'])
    mark+=point;
  }
  else if(ans.isCorrect==true)
  mark+=point;
});

var sm= new studentMark();
sm.mark=Math.round(mark)  ;
sm.test_id=this.userService.solveTest.test.test_id;
sm.student_id=this.userService.user.studentId;
//sm.studentId=
this.userService.saveMark(sm).subscribe(res=>{
  alert("yout mark is" + Math.round(mark) );
})

}
}
