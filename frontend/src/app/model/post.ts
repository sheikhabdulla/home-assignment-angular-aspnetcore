export interface Post {
    userId: number;
    id: number;
    title: string;
    body: string;
    favorite: boolean;
}

export interface PostDetail {
  author: string;
  commentCount: number;
  post: Post;
}
