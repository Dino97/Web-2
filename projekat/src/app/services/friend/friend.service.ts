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

  addFriend(username): Observable<any> {
    return this.handleFriendOperation("AddFriend", username);
  }

  acceptFriend(username): Observable<any> {
    return this.handleFriendOperation("AcceptFriendRequest", username);
  }

  declineFriend(username): Observable<any> {
    return this.handleFriendOperation("DeclineFriendRequest", username);
  }

  deleteFriend(username): Observable<any> {
    return this.handleFriendOperation("DeleteFriend", username);
  }

  handleFriendOperation(operation: string, username: string): Observable<any> {
    let httpOptions = {
      params: new HttpParams().set("friendUsername", username)
    };

    return this.http.post(this.baseUri + "Friend/" + operation, null, httpOptions);
  }
}
