# Sleep Fright

Controls
-----------------------------------------------------------
* W-A-S-D to move

* Use the mouse to aim

* Left click to shoot

* Right click to to throw grenade (if equipped)

Powerups
----------------------------------------------------------
* 50% chance to drop after killing a Hellephant, and one is spawned randomly in the map every 30 seconds

* Expire if not picked up after 10 seconds

* Each powerup lasts 10 seconds total

Type | Description
------------- | -------------
Minigun  | Red, shoot 3X faster
Slomo | Blue, freeze enemies in place
Sniper | Orange, shoot 50% slower, bullets pierce and do 100 damage

Enemies
----------------------------------------------------
* Continuously chase the player (unless a grenade is thrown, then they chase that)

Name | Health | Damage | Score Value
---- | ------ | ------ | -----------
Zombunny | 100 | 10 | 10
Zombear | 100 | 15 | 10
Hellephant | 450 | 50 | 50

Modes
----------------------------------------------------
* Waves
  * 5 second break between waves
  * 75% more enemies each wave
  * Try to get the highest wave reached
* Endless
  * No waves, constant enemies
  * Try to get the highest score
  
Weapons
------------------------------------------------
* Gun
  * Damage = 20
* Grenade
  * Damage = 100
  
Adjustments After Playtest
-----------------------------------------------
* Made the minigun color red to better differentiate it from normal firing
  * Tried to make it a laser, but the line renderer would disappear and lag so it was dropped
* Players now automatically buy health and grenades rather than having to press another button
* Fixed a spot in the wall where players couldn't get hit by the enemies
* Slomo powerup now completely freezes enemies instead of reducing their speed 66%
* Decreased the spawn rate of powerups
* Corrected the Hellephant hitbox
