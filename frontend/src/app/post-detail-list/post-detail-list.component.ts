import { Component,OnInit } from '@angular/core';
import { PostService } from '../services/post.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-post-detail-list',
  templateUrl: './post-detail-list.component.html',
  styleUrls: ['./post-detail-list.component.css'],
})
export class PostDetailListComponent implements OnInit {
  public datas: any[] = [];
  public showAllItems = false;
  public displayItemCount = 12;
  public showLoader: boolean = false;

  constructor(private postService: PostService) {}
  ngOnInit(): void {
    this.getAllPosts();
  }
  public getAllPosts(): void {
    this.postService.fetchAllPost().subscribe((res: any) => {
      this.datas = [...res];
      const itemCount = this.showAllItems
        ? this.datas?.length
        : this.displayItemCount;
      this.datas = this.datas.slice(0, itemCount);
    });
  }

  public onDeletePost(postId: any): void {
    this.postService.deletePost(postId).subscribe((res: any) => {
      Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Post Deleted Successfully...',
        showConfirmButton: false,
        timer: 1500,
      });
      this.getAllPosts();
    });
  }
  public onRefresh(): void {
    this.showLoader = true;
    this.postService.onPostsRefresh().subscribe((res: any) => {
      console.log('response :: ', res);
      this.getAllPosts();
      this.showLoader = false;
    }, (error) => this.showLoader = false);
  }
  public updatePost(postId: number, favourite: boolean): void {
    let data = {
      favourite,
    };
    this.postService.updatePost(postId, data).subscribe((res: any) => {
      this.getAllPosts();
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
