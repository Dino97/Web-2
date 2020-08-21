import { Component, OnInit, Input } from '@angular/core';
import { Company } from 'src/app/entities/company/company';

@Component({
  selector: 'app-company-display',
  templateUrl: './company-display.component.html',
  styleUrls: ['./company-display.component.css']
})
export class CompanyDisplayComponent implements OnInit {
  @Input() company: Company

  constructor() { }

  ngOnInit(): void {
  }

}
