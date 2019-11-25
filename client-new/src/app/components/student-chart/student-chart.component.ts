import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
const data = {
    chart: {
      caption: "Countries With Most Oil Reserves [2017-18]",
      subcaption: "In MMbbl = One Million barrels",
      xaxisname: "Country",
      yaxisname: "Reserves (MMbbl)",
      numbersuffix: "K",
      theme: "fusion"
    },
    data: [
      {
        label: "Venezuela",
        value: "290"
      },
      {
        label: "Saudi",
        value: "260"
      },
      {
        label: "Canada",
        value: "180"
      },
      {
        label: "Iran",
        value: "140"
      },
      {
        label: "Russia",
        value: "115"
      },
      {
        label: "UAE",
        value: "100"
      },
      {
        label: "US",
        value: "30"
      },
      {
        label: "China",
        value: "30"
      }
    ]
  };
  
@Component({
  selector: 'app-student-chart',
  templateUrl: './student-chart.component.html',
  styleUrls: ['./student-chart.component.scss']
})
export class StudentChartComponent implements OnInit {
  width = 600;
  height = 400;
  type = "column2d";
  dataFormat = "json";
  dataSource = data;
  studentId:number;
  constructor(private router:ActivatedRoute,private apiService:ApiService) { 
  }

  ngOnInit() {
  //   this.router.params.subscribe(data => {
  //     this.student=this.apiService.studentsForClass.find(s=>s.userId==+data['studentId']);
  //  });
   this.router.params.subscribe(data => {
    this.studentId=+data['studentId'];
 });
  }
}
