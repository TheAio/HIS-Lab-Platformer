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
- [x] Can be moved by player, left/right and jump
- [x] Sprite is oriented based on movement direction.
- [x] Is effected by gravity.
- [x] Can not move through platforms
### Key and door
- [x] Key can be picked up by the player character.
- [x] Door opens only when key picked up.
- [x] Door when open, takes the player to the next level.
- [x] When closed does nothing
### Levels
- [x] At least 2 levels.
- [x] Levels are loaded from text files.
  - [x] Player
  - [x] Platforms
  - [x] Keys
  - [x] Doors
### Graphics
- [x] All of the above elements have a functional graphical representation.
- [x] Tilesets are used
- [x] Collision accounts for the graphical representation.
### Bonus features
- [x] Add a coin entity and show the number of coins picked up somewhere on the screen.
- [x] Play a walk animation when the player moves, by toggling between the first and second tiles in characters.png
- [x] Add a special platform entity, that breaks when the hero hits it from underneath
  - [x] without changing anything in the hero class!
