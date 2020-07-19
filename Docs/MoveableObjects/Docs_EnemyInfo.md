# class EnemyInfo

Summary: handles health and death of and enemy

## attributes

public delegate void OnDeathEnemy(int number)

Summary: used for event OnDeathEnemy

public event OnDeathEnemy OnDeathEnemiesScore

Summary: invoked when an enemy dies, raises score

public event DelegateUpdateStatGUI OnEnemyCountChange;

Summary: Needed to know how many enemies are on the level

public Animator animator

Summary: enemy animator

public int score

Summary: Amount of score the player recieves when killing the enemy

public int maxHealth

Summary: Maximal health of the enemy

private int currentHealth

Summary: current health of the enemy

public string TagForGuiScore

Summary: Tag to find GUI element for showing score to the player

public string TagForGUIEnemiesLeft

Summary: Tag to find GUI element for showing left enemies to the player

## methods

public int CurrentHealth

Summary: get-Method for currentHealth

private void Start

Summary: Adds methods to event, sets currentHealth to maxHealth, sets "Animator" to needed components

private void update()

Summary: checks for enemy death, if enemy dies, invoke Die()

public void TakeDamage(int damage)

Summary: subtracts "damage" from "currentHealth"

public void Die()

Summary: invokes event to raise player score and destroys the enemy


