# GameOfLife
The exercise used in the Global Day of Code Retreat.

## Feature

+ 真 • 每个函数不超过 5 行（甚至都没超过 1 行）;
+ 真 • 无副作用：[函数副作用 - 维基百科，自由的百科全书](https://zh.wikipedia.org/wiki/%E5%87%BD%E6%95%B0%E5%89%AF%E4%BD%9C%E7%94%A8), [Side effect (computer science) - Wikipedia, the free encyclopedia](https://en.wikipedia.org/wiki/Side_effect_(computer_science))

## Instruction

Your task is to write a program to calculate the next
generation of Conway's game of life, given any starting
position. You start with a two dimensional grid of cells, 
where each cell is either alive or dead. The grid is finite, 
and no life can exist off the edges. When calculating the 
next generation of the grid, follow these four rules:

1. Any live cell with fewer than two live neighbours dies, 
   as if caused by underpopulation.
2. Any live cell with more than three live neighbours dies, 
   as if by overcrowding.
3. Any live cell with two or three live neighbours lives 
   on to the next generation.
4. Any dead cell with exactly three live neighbours becomes 
   a live cell.

Examples: `*` indicates live cell, `.` indicates dead cell

Example input: (4 x 8 grid)
```
4 8
........
....*...
...**...
........
```

Example output:
```
4 8
........
...**...
...**...
........
```
