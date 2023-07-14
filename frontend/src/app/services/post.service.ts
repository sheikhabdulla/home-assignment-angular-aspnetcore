import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs'
import { Post } from '../model/post';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  private BASE_URL = 'https://localhost:7262/api/';

  constructor(private http: HttpClient) {}

  public deletePost(postId: number): Observable<any> {
    return this.http.delete(`${this.BASE_URL}Posts/${postId}`);
  }
  public fetchAllPost(): Observable<Post[]> {
    return this.http.get<Post[]>(`${this.BASE_URL}Posts`);
  }
  public updatePost(postId: number, data: any): Observable<Post> {
    return this.http.post<Post>(
      `${this.BASE_URL}Posts/${postId}/favourite`,
      data
    );
  }
  public onPostsRefresh(): Observable<Post> {
    return this.http.get<Post>(`${this.BASE_URL}Data/refresh`);
  }
}
