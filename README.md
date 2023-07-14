# Home Assignment Angular, ASP.NET Core

## Description
1. Upon start gets users / posts / comments and store the data locally in json files
2. Supports the following actions (using the local json files)

-  Get all posts with Author and # of comments
-  sort by Author / Title
- view post and comments
- add / delete a comment
- delete a post
- mark /unmark post as favorite
- refresh all data from the original source and replaces the local files

## Workflow

1. Define the models:
   - Address
   - Comment
   - Company
   - Geo
   - Post
   - PostsResponse
   - PostWithAuthorAndComments
   - User

2. Create a controller for comments:
   - Inject the `JsonPlaceholderService` into the `CommentsController`.
   - Implement the following actions:
     - `GetComments`: Handle the HTTP GET request to retrieve all comments.
     - `GetComment`: Handle the HTTP GET request to retrieve a specific comment by ID.
     - `AddComment`: Handle the HTTP POST request to add a new comment.
     - `DeleteComment`: Handle the HTTP DELETE request to delete a comment by ID.

3. Create a controller for data management:
   - Inject the `JsonPlaceholderService` into the `DataController`.
   - Implement the `RefreshData` action to handle the HTTP GET request for refreshing the data.

4. Create a controller for posts:
   - Inject the `JsonPlaceholderService` into the `PostsController`.
   - Implement the following actions:
     - `GetPosts`: Handle the HTTP GET request to retrieve all posts.
     - `GetPost`: Handle the HTTP GET request to retrieve a specific post by ID.
     - `DeletePost`: Handle the HTTP DELETE request to delete a post by ID.
     - `UpdatePostFavourite`: Handle the HTTP POST request to update the favorite status of a post.

5. Implement the `JsonPlaceholderService` class:
   - Inject the `HttpClient` into the service.
   - Define private fields to store the file paths for users, posts, and comments.
   - Implement methods to load local data from files:
     - `LoadLocalPosts`: Deserialize and return a list of posts from the local JSON file.
     - `LoadLocalUsers`: Deserialize and return a list of users from the local JSON file.
     - `LoadLocalComments`: Deserialize and return a list of comments from the local JSON file.
   - Implement the `GetPostsAsync` method to retrieve posts, users, and comments, and construct `PostWithAuthorAndComments` objects.
   - Implement the `AddCommentAsync` method to add a new comment to the local list of comments and update the JSON file.
   - Implement the `DeleteCommentAsync` method to delete a comment from the local list of comments and update the JSON file.
   - Implement the `DeletePostAsync` method to delete a post from the local list of posts and update the JSON file.
   - Implement the `UpdatePostsAsync` method to update the local list of posts and save the changes to the JSON file.
   - Implement the `RefreshDataFromSourceAsync` method to fetch data from an external source and save it to local JSON files.
   - Implement additional helper methods as needed.
        

## Environment Setup


1. Install Visual Studio: Download and install Visual Studio from the official Microsoft website. Choose the version that suits your needs (e.g., Visual Studio Community, Professional, or Enterprise).

2. Open the project: Launch Visual Studio and open the project containing the API code.

3. Install the required dependencies: Ensure that you have the necessary dependencies installed in your project. The required dependencies include .NET Core SDK, Newtonsoft.Json, and System.Net.Http.

4. Restore NuGet packages: Right-click on the project in Visual Studio's Solution Explorer, then select "Restore NuGet Packages" to restore any missing packages and dependencies.

5. Verify target framework: Ensure that the project is targeting a compatible .NET Core version. You can check and modify the target framework by right-clicking on the project, selecting "Properties," and navigating to the "Target Framework" section.

6. Build the solution: Build the solution by selecting "Build" from the top menu and then clicking on "Build Solution." This step will compile the code and verify if there are any build errors.

7. Set up launch configuration: Configure the launch settings for your API. Right-click on the project, select "Properties," and navigate to the "Debug" tab. Specify the launch configuration, such as the project to run and the appropriate debugging options.

8. Run the API: Press F5 or click on the "Start Debugging" button to launch the API. Visual Studio will build the project, start the server, and open the API in your default browser.

9. Test the API: Once the API is running, you can test it using a tool like Postman or by sending HTTP requests directly from the browser. Test each endpoint to ensure that the API is functioning as expected.

10. Troubleshooting: If you encounter any issues during the setup or execution of the API, check the error messages, review the code for any potential mistakes, and consult the official Microsoft documentation or community resources for guidance.


## Build and Run API


1. Open Visual Studio: Launch Visual Studio on your machine.

2. Open the project: Open the project containing your API code in Visual Studio.

3. Restore NuGet packages: Right-click on the project in the Solution Explorer and select "Restore NuGet Packages" to ensure all necessary packages are installed.

4. Build the solution: Select "Build" from the top menu and choose "Build Solution" (or press Ctrl+Shift+B) to compile your project.

5. Set the startup project: Right-click on the project that contains your API code and select "Set as StartUp Project."

6. Configure the launch profile: In the project properties or launch settings, ensure that the project is set to launch using IIS Express or your desired web server.

7. Run the API: Press F5 or click on the "Start" button to start the API. This will build the project, start the web server, and open the Swagger UI in your default web browser.

8. Explore the Swagger UI: The Swagger UI provides a user-friendly interface for testing and exploring your API endpoints. It lists all the available endpoints and allows you to interact with them by sending requests and viewing responses.

9. Test API endpoints: In the Swagger UI, select an endpoint to test and provide any required parameters or request body data. Click "Try it out" to send the request and view the response. You can modify the request and try it multiple times if needed.

10. View response and status codes: The Swagger UI displays the response body, response headers, and the corresponding status code for each request. Use this information to verify the behavior of your API and ensure it is returning the expected results.

11. Debugging: If you need to debug your API, set breakpoints in your code by clicking in the left margin of the desired line. When the API reaches the breakpoint, Visual Studio will pause the execution, allowing you to inspect variables and step through the code to identify and fix any issues.

## Frontend

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 16.0.4.

### Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.
