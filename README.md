# The Tower

Unity Android Game (C#)

## Gameplay

Utilizes touch and drag mechanic to fling the player platform to platform.

## Gameplay Screenshots
![alt text](https://github.com/punch2dface/The-Tower/blob/master/Gameplay%20Reference/Screenshot_20200918-125745_The%20Tower.jpg)
![alt text](https://github.com/punch2dface/The-Tower/blob/master/Gameplay%20Reference/Screenshot_20200918-125753_The%20Tower.jpg)

## Problems That May Occur

Resolution is fixed to work on my phone. It is not universal. Will work on it later.

## Lessons Learned From Development
- Should Manage Planning Thoroughly
  - Had a lot of incidents where I would finish a function but later on made other functions difficult to implement
    - i.e. Scaling walls in proportion to the height of the level.
    - i.e. UI scales to aspect ratios
  - Prefabs and variants had different hierarchy amongs different scenes
  - Manage z Axis (layers) for gameobject
    - it was a mess in the beginning cause I did not layer them properly
- Scripting
  - Learned about IEnumerators and Coroutines
  - Learned about TimeScales
  - Learned about Values being accessed across different scenes
    - i.e. sound settings
- Sprites
  - change the size of images so that it will be easier to manage sprites
  
