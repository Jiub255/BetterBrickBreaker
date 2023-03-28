public class AAAAAAAAAA
{/*
	
	FIX:

	Fine tune the paddle's bounce feel.
		Make a "flat spot" in like the middle third that doesn't affect the natural bounce angle of the ball at all. 

	------------------------------------------------------------------

	TODO:

	Finish setting up all the menus.
		Put pauses where they should be. PauseManager is a singleton. 

	Finish save system.
		Game state saves
			How to save state of current level?
			Should I even worry about this for now? 
		High score saves

	Give a bonus for completing the game. And smaller ones for completing levels.
		That way you can still get a score if you die before the end, but if you complete the game you get a higher score. 

	Automatically set the 4 walls, paddle, bricks, and the UI based on screen size/resolution.
		Make sure the UI fits with the walls.
			Have the UI take a percentage of the top/bottom? And then the walls are set to a percent of screen height as well?
			Or just have panel-less UI below the paddle in the blank space?

	------------------------------------------------------------------

	Standard brick breaker game. 
	Keep it super simple.
	LOTS OF JUICE!!!
	
	Set amount of hand built levels.
	Get high score at end of game. 

	Different bricks have different effects.
		-Bounce ball in random direction.
		-Ball breaks brick and passes straight through (like glass).
		-Ball gets caught by brick and launched straight up/down/left/right. 
		-Balls speeds up/slows down. 
		-Brick explodes, destroying nearby bricks and launching the ball away quickly (Set ball speed to a set high value).

	Get powerups randomly from bricks. 
	Powerup drop chance depends on level or brick or both. 
		-Extra life.
		-Guns.
		-Longer paddle.
		-Slower ball.
		-Split ball.
		-Sticky paddle.
		-Other, new ideas. 

	Don't use physics for bouncing, just for collision detection. 
		Use _rb.MovePosition() in FixedUpdate so collisions still work. 
		Calculate ball's bounce angle in code. 
			Sharper angles the further the ball hits from the center of the paddle. 
			Brick angles will be pretty straightforward, but with a little randomness (except for special bricks). 
		Have ball handle bounce logic, not brick/paddle. 
		Make sure to avoid letting the ball go too sideways. Not sure how yet exactly. 

	Game flow:
		Main menu -> Gameplay -> Next level canvas -> Gameplay -> Beat Game -> Win canvas -> High score canvas -> Play again OR Main menu
							  OR
							  -> Die -> Death canvas -> High score canvas -> Play again OR Main menu






































*/}