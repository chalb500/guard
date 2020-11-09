import { Component, OnInit } from '@angular/core';
import { User } from './models/user';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(private accountService: AccountService) {}
  ngOnInit(): void {
    this.setCurrentUser();
  }
  setCurrentUser() {
    let user: User | undefined = undefined;
    const item = localStorage.getItem('user');
    user = item ? JSON.parse(item) : undefined;
    if (user) {
      this.accountService.setCurrent(user);
    }
  }
}
