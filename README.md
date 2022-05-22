# Bowling Game Kata

This is a solution to the Bowling Game Kata.

Here we have 3 folders:

1. `BowlingGame` folder contains the c# implementation of the solutions
2. `BowlingGame.Tests` folder contains the unit tests
3. `puml` folder contains the UML diagram

Inside the `BowlingGame` folder, we have 2 classes:

1. `Bowling.cs` class contains the solution for [Bowling - Coding Dojo](https://codingdojo.org/kata/Bowling/), which doesn't require checking for valid rolls and doesn't provide scores for intermediate frames.
2. `Game.cs` class contains the solution for [Bowling Game - Kata-log](https://kata-log.rocks/bowling-game-kata), which allows individual rolls and provide scores for intermediate frames.

The `FrameStatus.cs` file contains an enumerable `FrameStatus` that is used by `Bowling.cs` and `Game.cs`.
