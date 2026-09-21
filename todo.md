# TODO
-------------------------------------------------------------
- This is the central todo file, to track what we want todo -
-------------------------------------------------------------

## Learning goals
- [ ] Combine continuous acceleration (gravity) and collision.
- [ ] Use inheritance to organize, entities in a class hierarchy
- [ ] Use polymorphism to reduce coupling
- [ ] Use encapsulation when designing classes
---
## Requirements
### Player character
- [ ] Can be moved by player, left/right and jump
- [ ] Sprite is oriented based on movement direction.
- [ ] Is effected by gravity.
- [ ] Can not move through platforms
### Key and door
- [ ] Key can be picked up by the player character.
- [ ] Door opens only when key picked up.
- [ ] Door when open, takes the player to the next level.
- [ ] When closed does nothing
### Levels
- [ ] At least 2 levels.
- [ ] Levels are loaded from text files.
  - [ ] Player
  - [ ] Platforms
  - [ ] Keys
  - [ ] Doors
### Graphics
- [ ] All of the above elements have a functional graphical representation.
- [ ] Tilesets are used
- [ ] Collision accounts for the graphical representation.
### Bonus features
- [ ] Add a coin entity and show the number of coins picked up somewhere on the screen.
- [ ] Play a walk animation when the player moves, by toggling between the first and second tiles in characters.png
- [ ] Add a special platform entity, that breaks when the hero hits it from underneath
  - [ ] without changing anything in the hero class!
