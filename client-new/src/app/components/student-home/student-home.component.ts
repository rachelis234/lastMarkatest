import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";

@Component({
  selector: "app-student-home",
  templateUrl: "./student-home.component.html",
  styleUrls: ["./student-home.component.css"]
})
export class StudentHomeComponent implements OnInit {
  constructor(private route: Router, private cookieService: CookieService) {}

  ngOnInit() {}
  logOut() {
    this.cookieService.delete("userName");
    this.cookieService.delete("password");
    this.route.navigate([""]);
  }
}
