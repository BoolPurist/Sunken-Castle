# class PauseMenu

Game is paused when ESC Button is clicked, resumed when clicked again, also resumed when clicked on Button 'RESUME', game goes to Main Menu when Button 'MENU' is clicked, game quits when Button 'QUIT' is clicked.

## public attributes

public GameObject pauseMenuUI

Summary: User Interface for Pause Menu is created.

## methods

**public void Resume()**

Summary: Resumes game, clock is reset to 1f, pausMenuUI is set false.


**private void Pause()**

Summary: Pauses game, clock is set to 0f, pauseMenuUI is set true.
