using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }

    /*
    Exceeding Requirements:
    This Eternal Quest program includes several features that go beyond the core requirements:

    1. Leveling System:
       - Players gain levels based on their total score (1 level per 1000 points).
       - The current level is displayed in the player info.

    2. Achievement System:
       - Players can earn achievements for reaching certain milestones.
       - Current achievements include:
         a) "Goal Setter" for creating 5 goals
         b) "Week Warrior" for maintaining a 7-day streak
         c) "Point Master" for reaching 5000 points
       - Achievements are displayed in the player info and saved/loaded with the game state.

    3. Streak System:
       - The program tracks the number of consecutive days a player completes at least one goal.
       - The current streak is displayed after recording an event and in the player info.
       - Failing to complete a goal resets the streak to 0.

    4. Goal Categories:
       - Players can assign categories to their goals for better organization.
       - Goals are displayed grouped by their categories.
       - Uncategorized goals are listed separately.

    5. Enhanced Player Info:
       - A new menu option displays comprehensive player information, including:
         a) Current level
         b) Total score
         c) Current streak
         d) List of earned achievements

    6. Improved Save/Load Functionality:
       - The save and load  functions have been updated to include all new features:
         a) Player level, score, and streak
         b) Achievements
         c) Goal categories

    These additional features enhance user engagement, provide more motivation for consistent goal completion,
    and offer better organization of goals. They transform the Eternal Quest program from a simple goal tracker
    into a more gamified, rewarding experience that encourages long-term use and personal growth.
    */
}