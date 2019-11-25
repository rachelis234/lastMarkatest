import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Teacher } from 'src/app/Models/Teacher';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/Models/User';


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  teacher: Teacher = new Teacher();
  constructor(private userService: UserService, private router: Router) {
    this.teacher.user = new User();
  }

  ngOnInit() {
    // $(function () {
    //   $('.button-checkbox').each(function () {
    //     var $widget = $(this),
    //       $button = $widget.find('button'),
    //       $checkbox = $widget.find('input:checkbox'),
    //       color = $button.data('color'),
    //       settings = {
    //         on: {
    //           icon: 'glyphicon glyphicon-check'
    //         },
    //         off: {
    //           icon: 'glyphicon glyphicon-unchecked'
    //         }
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
    //       else {
    //         $button
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
  signUp() {
    debugger;
    this.teacher.user.status = 1;
    this.teacher.design_id = 0;
    this.teacher.userId = 0;
    this.userService.addUser(this.teacher).subscribe(
      (res) => {
        console.log(res);
        this.router.navigate(['']);
      },
      (err) => 
      console.log(err));
  console.log('call');
    }
}