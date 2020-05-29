# class UpdateStatsText

Serves as an interface for other game objects to display a status as number in text displayed on
the player view.

## private attributes

**private string textTemplate**

Summary: Holds the text given by the unity inspector to be used later.

**private int currentStat = 0**

Summary: Stores the current number representing the a status.

## methods

**private void UpdateText()**

Summary: Updates the displayed text with current number as status provided by attribute "currentStat".

## callback methods

**public void CallbackUpdateStats(int number)**

Summary: Sets the attribute "currentStat" equal with the number as parameter and invokes the method UpdateText() to update the displayed text.

Parameter number: integer value provided by the fired events.

**public void CallbackUpdateStatsAdd(int number)**

Summary: Adds the parameter "number" to the attribute "currentStat" and invokes the method UpdateText() to update the displayed text.

Parameter number: integer value provided by the fired events.

**public void CallbackUpdateStatsReset()**

Summary: Sets the attribute "currentStat" equal with the zero and invokes the invokes the method UpdateText() to update the displayed text.
