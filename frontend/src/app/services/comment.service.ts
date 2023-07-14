import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Comment } from '../model/comment';

@Injectable({
  providedIn: 'root',
})
export class CommentService {
  private BASE_URL = 'https://localhost:7262/api/';

  constructor(private http: HttpClient) {}

  public postComment(comment: Comment): Observable<Comment> {
    return this.http.post<Comment>(`${this.BASE_URL}Comments/`, comment);
  }
  public deleteComment(commentId: number): Observable<any> {
    return this.http.delete(`${this.BASE_URL}Comments/${commentId}`);
  }
  public fetchAllComment(): Observable<Comment[]> {
    return this.http.get<Comment[]>(`${this.BASE_URL}Comments`);
  }
  
}
