Race On

	1. My goal with the game was to create a car that works similarly to a real life car.  With acceleration, drift, back pedalling and all the other good stuff. After I could achieve that I wanted to make more cars and have them race each other on a track by using the new input system. 
	It took me many tries to achieve this goal, because I wanted to try to make it on my own, using minimal skills in C# because I wanted to see personally what  level I am on . I tried using quaternions, mouse steering, and when that didn’t work I decided to watch a guide and that helped me a lot. I worked with class mates and I learnt a lot about not only code, but structure as well. 
	
	
	
	2. The only packages used is the new Input System and TextMeshPro.  In order to start my game, you need to open the "MainMenu" scene, from there you press "Play" and you can choose 1 out of three levels. First 2 are playable, the third one I founds no reason to make  another track since they all work the same. After selecting a level you can start racing using these inputs:
	- Red Car: arrows
	- Grey Car: WASD
	- Black Car(if you want to play as it you will have to activate it form the inspector): IJKL 
	After 2 laps, the winner will be showcased and the you will be able to either move on with the next race, restart or go back to main menu. The last 2 options can be used when pressing the "Esc" button, this will pause the game, and you can resume by pressing "Resume" or pressing "Esc" button again.
	
	3. As for the code structure I have multiple scripts taking care of different things here are the scripts at hand:
	-  CarController - where I made the car physics and gave it move properties
	- Car Input -  Currently there is not much in there, I could merge it together with the CarController but I decided to have them separate with the idea in mind that you can add more inputs and have them easily displayed in the input script. Like nitro or shoot a rocket, etc….
	- Checkpoint - this is to give the colliders a checkpoint number and a bool that determines if it is       the finish line
	- Lap counter - it is by far the biggest one, it tracks the checkpoint number to determine how many laps have been passed. It is a very easy system that works by adding to the number of checkpoints passed for each OnTriggerEnter with the car.  The reason behind this system is to not have the car backtrack and get to the finish line thus winning. So this takes care to have the car fallow the track  correctly or else they won't hit checkpoints therefore they will not be able to activate the finish line
	- PlacementHandler - tracks the cars checkpoints passed and the time at which it has passed them in order to declare the winner at the end of a race.
	- Finish Race - Here is where I keep track of when the amount of laps is needed to complete the race and it activates only when the number of laps to complete has been met. Then it will open the finish race menu.
	- PauseMenu - This is a very simple code that holds a lot of the code for buttons to press when you pause the game. It has a input("Esc" that when is pressed it will pause the time and opens the menu )
	- MainMenu - Takes care of the scenes that will start up when you select a level and that is about it.
	
	4. Sources: 
	For the menu.
	https://www.youtube.com/watch?v=JivuXdrIHK0&list=LL&index=20&t=3s
	For the car.
	https://www.youtube.com/watch?v=DVHcOS1E5OQ&list=PLyDa4NP_nvPfmvbC-eqyzdhOXeCyhToko
	For the Input.
	https://www.youtube.com/watch?v=HmXU4dZbaMw&t=317s
	Other needs. 
	https://docs.unity3d.com/Manual/index.html
	https://forum.unity.com/
	
Version 2022.3.10f1
