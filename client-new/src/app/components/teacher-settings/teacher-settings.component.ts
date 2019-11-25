import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { CookieService } from 'ngx-cookie-service';


@Component({
  selector: 'app-teacher-settings',
  templateUrl: './teacher-settings.component.html',
  styleUrls: ['./teacher-settings.component.css']
})
export class TeacherSettingsComponent implements OnInit {

  constructor(private userService: UserService, private router: ActivatedRoute,private cookieService: CookieService,private route:Router) {
   //this.teacher= this.userService.user;
      // this.router.params.subscribe(params => this.teacher = JSON.parse(params['user']));
    // this.getTeacherByUserId(this.router.snapshot.params['user_id']);
  }
  ngOnInit() {
  //   $(function(){
  //     $('.button-checkbox').each(function(){
  //       var $widget = $(this),
  //       $button = $widget.find('button'),
  //       $checkbox = $widget.find('input:checkbox'),
  //       color = $button.data('color'),
  //       settings = {
  //           on: {
  //             icon: 'glyphicon glyphicon-check'
  //           },
  //           off: {
  //             icon: 'glyphicon glyphicon-unchecked'
  //           }
  //       };
  
  //     $button.on('click', function () {
  //       $checkbox.prop('checked', !$checkbox.is(':checked'));
  //       $checkbox.triggerHandler('change');
  //       updateDisplay();
  //     });
  
  //     $checkbox.on('change', function () {
  //       updateDisplay();
  //     });
  
  //     function updateDisplay() {
  //       var isChecked = $checkbox.is(':checked');
  //       // Set the button's state
  //       $button.data('state', (isChecked) ? "on" : "off");
  
  //       // Set the button's icon
  //       $button.find('.state-icon')
  //         .removeClass()
  //         .addClass('state-icon ' + settings[$button.data('state')].icon);
  
  //       // Update the button's color
  //       if (isChecked) {
  //         $button
  //           .removeClass('btn-default')
  //           .addClass('btn-' + color + ' active');
  //       } 
  //             else 
  //             { 
  //                 $button
  //           .removeClass('btn-' + color + ' active')
  //           .addClass('btn-default');
  //       }
  //     }
  //     function init() {
  //       updateDisplay();
  //       // Inject the icon if applicable
  //       if ($button.find('.state-icon').length == 0) {
  //         $button.prepend('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i> ');
  //       }
  //     }
  //     init();
  //   });
  // });
  }
  logOut() {
    this.cookieService.delete("userName");
    this.cookieService.delete("password");
    this.route.navigate(['']);
  }
}