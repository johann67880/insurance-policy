import { Component, ViewEncapsulation } from "@angular/core";
import { Router } from '@angular/router';
import { MatIconRegistry } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: "app-root",
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  appTitle = "Insurance Policy";

  constructor(public router: Router, matIconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    // icons
    matIconRegistry.addSvgIcon(
      'add',
      sanitizer.bypassSecurityTrustResourceUrl('../assets/images/add.svg'));
  }
}
