import { Component, OnInit } from '@angular/core';
import { UserProfile } from "../profile/user-profile"
import { FriendService } from "../../services/friend/friend.service"
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-friend-list',
  templateUrl: './friend-list.component.html',
  styleUrls: ['./friend-list.component.css']
})
export class FriendListComponent implements OnInit {

  friends: UserProfile[];
  requests: UserProfile[];

  constructor(private friendService: FriendService) {
    this.friends = [];
    this.requests = [];
  }

  ngOnInit(): void {
    this.friendService.getFriends().subscribe(friends => friends.map(friend => {
      this.friends.push(new UserProfile(friend.userName, friend.firstName, friend.lastName, friend.address))
    }));
    
    this.friendService.getFriendRequests().subscribe(requests => requests.map(sender => {
      this.requests.push(new UserProfile(sender.userName, sender.firstName, sender.lastName, sender.address))
    }));
  }

  addFriend(username) {
    this.friendService.addFriend(username).subscribe(_ => { window.location.reload(); });
  }

  deleteFriend(username) {
    this.friendService.deleteFriend(username).subscribe(_ => { window.location.reload(); });
  }

  acceptFriend(username) {
    this.friendService.acceptFriend(username).subscribe(_ => { window.location.reload(); });
  }

  declineFriend(username) {
    this.friendService.declineFriend(username).subscribe(_ => { window.location.reload(); });
  }
}