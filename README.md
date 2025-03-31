# HD-Custom-Program

This is my submission for HD band in the unit Object Oriented Programming at Swinburne University, implemented using C#.
## Summary of Program
The game that I intend to create is Asteroid, a simple 2D shooting game. It should be able to display a simple start menu, which will get the player to the game when clicking the start button. The player should then be able to move using the mouse pointer and shoot at asteroids to gain points. If the player hits an asteroid, the jet's health will decrement and when it gets down to 0, the game ends.

This program extends the D custom program in both functionality and design. This time, there are 2 different kinds of asteroids: Big Asteroid – which takes 2 shots to take down, and Small Asteroid, which takes 1 shot to take down. The game has 2 different buffs for the jet to collect while playing the game: Heart for extra health and Ammo for extra bullets.

The game logic will be managed through GameManager, while states and operations will be managed through StateManager.
I implemented the Factory Method design pattern for creating asteroids and buffs, while States was managed using the State pattern and Singleton pattern for the GameManager.

![image](https://github.com/user-attachments/assets/71f519f0-6974-48a5-981a-9dd8b82dabc5)
*An image of the final product*
