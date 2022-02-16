# bomberman-clone

Bomberman clone for codelex gamejam.

Currently basic and buggy functionality includes:

- grid map consisting of impassable walls;
- grid map of impassable destroyable objects (barrels);
- ability for the player to move around using WSAD;
- ability for the player to place bombs using spacebar;
- bomb explosions currently affect:
  - box objects (barrels);
  - monsters;
  - player;
  - other bombs in the explosion radius;
- ability for the player to pick up power ups which currently include:
  - power up for increasing bomb explosion radius;
  - power up for increasing the maximum consecutive bomb count that can be placed by the player;
  - power up for increasing player lives;
- monsters (currently slimes) which are also limited by the gridmap and kill the player upon touching it's body.

Most immediate bug is the player being stuck between bombs on placement. Using platform effector has mixed results with this.

TODO:
- add a working main menu;
- add win conditions and exit portal upon fulfilling them;
- add more power ups;
- add more monsters (maybe);
- add more levels;
- add random level placement for destroyable objects
