import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-smed-acc',
  templateUrl: './smed-acc.component.html',
  styleUrls: ['./smed-acc.component.css']
})
export class SmedAccComponent implements OnInit {
  @Input() word: string

  constructor() { }

  ngOnInit(): void {
  }

}
