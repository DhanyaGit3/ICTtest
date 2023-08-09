import { Component } from '@angular/core';
import { FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-my-page',
  templateUrl: './my-page.component.html',
  styleUrls: ['./my-page.component.scss']
})
export class MyPageComponent {
  constructor() {    
  }
   generateOTP() {
          
    // Declare a digits variable 
    // which stores all digits
    var digits = '0123456789';
    let OTP = '';
    for (let i = 0; i < 4; i++ ) {
        OTP += digits[Math.floor(Math.random() * 10)];
    }
    return OTP;
}
  sendOTP(){
    var OTPtosend = this.generateOTP();
    Email.send({
      Host: "smtp.gmail.com",
      To : '<dhanyakrishnansu3@gmail.com>',
      From : "<dhanyakrishnansu3@gmail.com>",
      Subject : "<sending otp>",
      Body : OTPtosend,
      }).then(
        alert("mail sent successfully")
      );

  }

}
