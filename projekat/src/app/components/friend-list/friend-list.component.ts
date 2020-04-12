import { Component, OnInit } from '@angular/core';
import { UserProfile } from "../profile/user-profile"

@Component({
  selector: 'app-friend-list',
  templateUrl: './friend-list.component.html',
  styleUrls: ['./friend-list.component.css']
})
export class FriendListComponent implements OnInit {

  friends: UserProfile[];

  constructor() { 
    this.friends = [
      new UserProfile("Vladimirko", "Isus", "Hristov", "Kod masinske")
    ];
  }

  ngOnInit(): void {
  }

}