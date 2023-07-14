import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { PostService } from '../services/post.service';
import { CommentService } from '../services/comment.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Post, PostDetail } from '../model/post';

@Component({
  selector: 'app-resource-card',
  templateUrl: './resource-card.component.html',
  styleUrls: ['./resource-card.component.css'],
})
export class ResourceCardComponent implements OnInit {
  public posts: any[] = [];
  public comments: any[] = [];
  public inputValue: any;
  public searchText: any;
  public postId: any;
  public showAllItems = false;
  public sortOption: string = 'title';
  public displayItemCount = 3;
  public form: FormGroup = new FormGroup({
    name: new FormControl('', [Validators.required]),
    email: new FormControl('', [Validators.required, Validators.email]),
    body: new FormControl('', [Validators.required]),
  });

  constructor(
    private postService: PostService,
    private commentService: CommentService
  ) {}

  ngOnInit(): void {
    this.getAllPosts();
    this.getAllComments();
  }
  public getData(postId: number): void {
    this.postId = postId;
    console.log('post id ;; ', postId);
  }

  public onSubmit() {
    console.log('Check Form Value :: ', this.form.value);
    const data = {
      postId: this.postId,
      ...this.form.value,
    };
    this.commentService.postComment(data).subscribe((res: any) => {
      console.log('Comment post successfully.....', res);
      this.getAllPosts();
      this.getAllComments();
      this.form.reset();
    });
  }

  public getAllPosts(): void {
    this.postService.fetchAllPost().subscribe(
      (res: any) => {
        this.posts = [...res];
        this.onSortOptionChange();
        const itemCount = this.showAllItems
          ? this.posts?.length
          : this.displayItemCount;
        this.posts = this.posts.slice(0, itemCount);
      },
      (error) => console.log('SDFdsaf', error)
    );
  }
  public onSortOptionChange() {
    switch (this.sortOption) {
      case 'author':
        this.posts.sort((a: PostDetail, b: PostDetail) => {
          if (a.author < b.author) return -1;
          if (a.author > b.author) return 1;
          return 0;
        });
        console.log("author", this.posts);
        
        break;
      case 'title':
        this.posts.sort((a: PostDetail, b: PostDetail) => {
          if (a.post.title < b.post.title) return -1;
          if (a.post.title > b.post.title) return 1;
          return 0;
        });
        console.log('title', this.posts);

        break;
      default:
        break;
    }
  }

  public getAllComments(): void {
    this.commentService.fetchAllComment().subscribe(
      (res: any) => {
        this.comments = [...res];
        console.log('Check comments :: ', res);
      },
      (error) => console.log('SDFdsaf', error)
    );
  }

  public deleteComment(commentId: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.commentService.deleteComment(commentId).subscribe(
          (res: any) => {
            this.getAllComments();
            console.log('Check ssddd :: ', res);
          },
          (error) => console.log('SDFdsaf', error)
        );
      }
    });
  }

 
  public onDeletePost(postId: number): void {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.postService.deletePost(postId).subscribe((res: any) => {
          console.log('Post delete successfully.....');
          this.getAllPosts();
          this.getAllComments();
        });
      }
    });
  }
  public loadAllResources(): void {
    this.showAllItems = true;
    this.getAllPosts();
  }
  public lessShowResources(): void {
    this.showAllItems = false;
    this.getAllPosts();
  }
}
