import { Component, OnInit, ViewChild } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Student } from "src/app/Models/Student";
import { ApiService } from "src/app/services/api.service";
import { MatTableDataSource, MatTable, MatDialog } from "@angular/material";
import { MatButtonModule } from "@angular/material/button";

@Component({
  selector: "app-view-students",
  templateUrl: "./view-students.component.html",
  styleUrls: ["./view-students.component.css"]
})
export class ViewStudentsComponent implements OnInit {
  id: number;
  // displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);

  // applyFilter(filterValue: string) {
  //   this.dataSource.filter = filterValue.trim().toLowerCase();
  // }
  displayedColumns: string[] = ["name", "action"];
  dataSource: Student[];

  @ViewChild(MatTable, { static: true }) table: MatTable<any>;

  constructor(
    private router: ActivatedRoute,
    private apiService: ApiService,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.router.params.subscribe(data => {
      this.id = +data["class_id"];
      this.apiService.getStudentsForClass(this.id).subscribe(
        (res: Student[]) => (
          (this.apiService.studentsForClass = res), (this.dataSource = res)
        ),
        err => console.log(err)
      );
    });
  }
  deleteStudent(studentId: number) {
    this.apiService.deleteStudent(studentId).subscribe(
      _res => {
        this.apiService.studentsForClass = this.apiService.studentsForClass.filter(
          item => item.userId !== studentId
        );
        new alert("deleted!!!");
      },
      err => console.log(err)
    );
  }
  putAction(action, obj) {
    obj.action = action;
  }
  // openDialog(action, obj) {
  //   obj.action = action;
  //   const dialogRef = this.dialog.open(DialogBoxComponent, {
  //     width: "250px",
  //     data: obj
  //   });

  //   dialogRef.afterClosed().subscribe(result => {
  //     if (result.event == "Add") {
  //       this.addRowData(result.data);
  //     } else if (result.event == "Update") {
  //       this.updateRowData(result.data);
  //     } else if (result.event == "Delete") {
  //       this.deleteRowData(result.data);
  //     }
  //   });
  // }

  addRowData(row_obj) {
    // var d = new Date();
    // this.dataSource.push({
    //   studentId: d.getTime(),
    //   user: row_obj.name
    // });
    this.table.renderRows();
  }
  // updateRowData(row_obj) {
  //   this.dataSource = this.dataSource.filter((value, key) => {
  //     if (value.id == row_obj.id) {
  //       value.name = row_obj.name;
  //     }
  //     return true;
  //   });
  // }
  // deleteRowData(row_obj) {
  //   this.dataSource = this.dataSource.filter((value, key) => {
  //     return value.id != row_obj.id;
  //   });
  // }
}
