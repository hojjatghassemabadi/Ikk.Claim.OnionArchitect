import { Component, OnInit, ElementRef,Inject  } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { DOCUMENT } from '@angular/common';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  faCoffee = faCoffee;
  constructor(private auth:AuthService,private elRef:ElementRef,@Inject(DOCUMENT) private document: Document) { }

  ngOnInit(): void {
  }

  ngAfterViewInit() {
     var sideMenu = this.elRef.nativeElement.querySelector('aside');
  
  }
  menuOpen(){
    (document.querySelector('aside') as HTMLElement).style.display = 'block';
  }
  closeMenu(){
    (document.querySelector('aside') as HTMLElement).style.display = 'none';
  }
  nighttheme(){
    (document.querySelector('.container')as HTMLElement).classList.toggle('dark-theme-variables');
    (document.querySelector('aside')as HTMLElement).classList.toggle('dark-theme-variables');
    //document.body.classList.toggle('dark-theme-variables');
     (document.querySelector('.moon') as HTMLElement).classList.toggle('active');
     (document.querySelector('.sun') as HTMLElement).classList.toggle('active');
  }
  logout(){
    this.auth.signOut();
  }
}
