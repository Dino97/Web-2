import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserProfile } from 'src/app/components/profile/user-profile';

@Injectable({
  providedIn: 'root'
})
export class FriendService {

  readonly baseUri: string = "http://localhost:52482/api/";

  constructor(private http: HttpClient) { }

  getFriends(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUri + "Friend/GetFriends");
  }

  getFriendRequests(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUri + "Friend/GetFriendRequests");
  }

  addFriend(username) {

  }

  acceptFriend(username) {

  }

  declineFriend(username) {
    
  }

  deleteFriend(username) {
    let body = { friendUsername: username };

    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };

    this.http.post(this.baseUri + "Friend/DeleteFriend", body, httpOptions);
    console.log(body);
  }
}
