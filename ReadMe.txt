Development environment used:
Visual Studio 2012
Target Framework: 4.5

Solution contains following projects
Contracts: Contains the interface contract for the Business Objects.
EvolutionRules: Contains all the Evolution rules and a factory which creates the Chain of Responsibility of these rules. This might seem like an over kill but in real life Business rules are the part of application which quickly get out of hand into an unmaintanable state.
GameOfLife: Console app with one scenario for the game.
GameOfLifeBO: Contains the business objects for the game.
	Board/ Cell: Represents the board and cells within the board.
	BoardTicker: Class which moves the board to the next generation by one tick at a time.
	BoardView: Prints the board on console.

	The above class design is quite similar to a MVC pattern.

Tests: Contains the unit test for the Board and EvolutionRules.

Rules of the Game of Life:
1.Any live cell with fewer than two live neighbours dies, as if caused by under-population.
2.Any live cell with two or three live neighbours lives on to the next generation.
3.Any live cell with more than three live neighbours dies, as if by overcrowding.
4.Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
