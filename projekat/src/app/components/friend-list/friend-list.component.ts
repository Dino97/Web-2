import { Component, OnInit } from '@angular/core';
import { UserProfile } from "../profile/user-profile"
import { FriendService } from "../../services/friend/friend.service"
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-friend-list',
  templateUrl: './friend-list.component.html',
  styleUrls: ['./friend-list.component.css']
})
export class FriendListComponent implements OnInit {

  friends;
  requests;

  constructor(private friendService: FriendService, private toastr: ToastrService) {
    this.friends = [];
    this.requests = [];
  }

  ngOnInit(): void {
    this.refresh();
  }

  addFriend(usernameTextbox: HTMLInputElement) {
    this.friendService.addFriend(usernameTextbox.value).subscribe(_ => { 
      this.refresh();
      this.toastr.success("", "Friend request sent");
    });
    usernameTextbox.value = "";
  }

  deleteFriend(username) {
    this.friendService.deleteFriend(username).subscribe(_ => { 
      this.refresh();
      this.toastr.success(`You are no longer friends with ${username}.`, "Friend removed");
    });
  }

  acceptFriend(username) {
    this.friendService.acceptFriend(username).subscribe(_ => { 
      this.refresh();
      this.toastr.success(`You are now friends with ${username}.`, "Friend request accepted");
    });
  }

  declineFriend(username) {
    this.friendService.declineFriend(username).subscribe(_ => { 
      this.refresh();
      this.toastr.success("", "Friend request declined");
    });
  }

  refresh() {
    this.friendService.getFriends().subscribe(friends => this.friends = friends);
    this.friendService.getFriendRequests().subscribe(requests => this.requests = requests);
  }
}