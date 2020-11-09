import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { ErrorComponent } from '../error/error.component';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public email: string = '';
  public password: string = '';
  public loggedIn: boolean = false;

  constructor(
    private accountService: AccountService,
    private dialog: MatDialog,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.getCurrentUser();
  }
  login() {
    this.accountService.login(this.email, this.password).subscribe(
      (response) => {
        console.log(response);
        this.loggedIn = true;
        this.router.navigate(['customer-list']);
      },
      (error) => {
        console.error(error);
        this.dialog.open(ErrorComponent, {
          data: {
            message: 'Your login information are incorrect!',
          },
        });
      }
    );
  }
  logout() {
    this.accountService.logout();
  }
  getCurrentUser() {
    this.accountService.currentUser$.subscribe(
      (user) => {
        this.loggedIn = !!user;
      },
      (error) => console.error(error)
    );
  }
}
