using System;
using System.Collections.Generic;

// Define the Comment class
public class Comment
{
    // Member variables with correct naming convention
    private string _commenterName;
    private string _commentText;

    // Constructor to initialize Comment attributes
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    // Method to get the details of the comment
    public string GetCommentDetails()
    {
        return $"Comment by {_commenterName}: {_commentText}";
    }
}

// Define the Video class
public class Video
{
    // Member variables with correct naming convention
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    // Constructor to initialize Video attributes
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to display video details along with comments
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}, Author: {_author}, Length: {_lengthInSeconds} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        foreach (var comment in _comments)
        {
            Console.WriteLine(comment.GetCommentDetails());
        }
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        // Create video objects with title, author, and length
        Video video1 = new Video("Cool Product Unboxing", "John Doe", 300);
        Video video2 = new Video("How to Use Our Product", "Jane Smith", 600);
        Video video3 = new Video("Product Review", "Emily Johnson", 450);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "This product looks awesome!"));
        video1.AddComment(new Comment("Charlie", "Can’t wait to try this!"));

        // Add comments to video2
        video2.AddComment(new Comment("David", "Very informative, thank you!"));
        video2.AddComment(new Comment("Eve", "I love this product!"));
        video2.AddComment(new Comment("Frank", "Will buy this soon!"));

        // Add comments to video3
        // Creativity: Added an extra video and comments for a more realistic example.
        video3.AddComment(new Comment("Grace", "Very detailed review!"));
        video3.AddComment(new Comment("Henry", "Helpful insights, thanks!"));
        video3.AddComment(new Comment("Isabella", "Good job on this review!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through the videos and display details
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
            Console.WriteLine(); // Extra line for better readability
        }
    }
}
