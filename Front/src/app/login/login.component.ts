import { Component, OnInit } from '@angular/core';
import {User} from './User';
import {LoginService} from './login.service';
import {FormBuilder} from '@angular/forms';
import {MatSnackBar} from '@angular/material/snack-bar';
import {Router} from '@angular/router';
import {AuthGuardChildService} from '../guards/auth-guard-child.service';
import {AuthGuardService} from '../guards/auth-guard.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  // @ts-ignore
  user: User;


  loginForm = this.formBuilder.group({
    login: '',
    password: ''
  });


  constructor(
    private router: Router,
    private fb: FormBuilder,
    private service: LoginService,
    private formBuilder: FormBuilder,
    private snackbar: MatSnackBar) { }

  ngOnInit(): void {
  }

  openSnackBar(message: string, action: string): void {
    this.snackbar.open(message, action, {
      duration: 2000,
    });
  }

  onSubmit(): void{
    this.service.post(this.loginForm.value).subscribe(
      success => {
        let {data} = success;
        if (data.success){
          this.openSnackBar('Usuário logado com sucesso', 'Authenticate');

          this.router.navigate(['/products']);
        }else{
          this.openSnackBar(data.error, 'Error');
        }
      },
      error => {
        console.log(error);
        this.openSnackBar('Não foi possivel logar no sistema.', 'Error');
      }
    );
  }

}
