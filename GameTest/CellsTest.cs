using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwaysGameOfLife;

namespace GameTest
{
    [TestClass]
    public class CellsTest
    {
        [TestMethod]
        public void GameExists()
        {
            GameOfLife game = new GameOfLife();
            Assert.IsNotNull(game);
        }
        [TestMethod]
        public void GameWithArgumentsExists()
        {
            GameOfLife game = new GameOfLife(2, 2);
            Assert.IsNotNull(game);
        }
        [TestMethod]
        public void CanCreateGrids()
        {
            GameOfLife game = new GameOfLife(3, 3);
            Assert.AreEqual(9, game.grid.Length);
        }
        [TestMethod]
        public void CellsStartDead()
        {
            GameOfLife game = new GameOfLife(3, 3);
            Assert.IsFalse(game.grid[1,1]);
        }
        public void CellsCanChangeState()
        {
            GameOfLife game = new GameOfLife(3, 3);
            game.grid[1, 1] = true;
            Assert.IsTrue(game.grid[1, 1]);
        }
        [TestMethod]
        public void CountNeighbors()
        {
            GameOfLife game = new GameOfLife(3, 3);
            game.grid[0, 0] = true;
            Assert.AreEqual(1, game.GetAliveNeighbors(1, 1));
        }
        [TestMethod]
        public void EdgeCase()
        {
            GameOfLife game = new GameOfLife(3, 3);
            Assert.IsTrue(game.IsEdge(0,0));
            Assert.IsTrue(game.IsEdge(2, 2));
            Assert.IsTrue(game.IsEdge(0, 2));
            Assert.IsTrue(game.IsEdge(2, 0));
        }

        [TestMethod]
        public void Rule1()
        //1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        {
            GameOfLife game = new GameOfLife(3, 3);
            game.grid[1, 1] = true;
            game.Tick();
            Assert.IsFalse(game.grid[1, 1]);
        }

        [TestMethod]
        public void Rule1OnLargerBoard()
        //1. Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        {
            GameOfLife game = new GameOfLife(8, 8);
            game.grid[1, 1] = true;
            game.grid[5, 5] = true;
            game.Tick();
            Assert.IsFalse(game.grid[1, 1]);
            Assert.IsFalse(game.grid[5, 5]);
        }
        [TestMethod]
        public void Blinker()
        {
            GameOfLife game = new GameOfLife(5, 5);
            game.grid[1, 2] = true;
            game.grid[2, 2] = true;
            game.grid[3, 2] = true;
            game.Tick();
            Assert.IsFalse(game.grid[1, 2]);
            Assert.IsFalse(game.grid[3, 2]);
            Assert.IsTrue(game.grid[2, 2]);
        }

        [TestMethod]
        public void Toad()
        {
            GameOfLife game = new GameOfLife(6, 6);
            game.grid[2, 2] = true;
            game.grid[2, 3] = true;
            game.grid[2, 4] = true;
            game.grid[3, 1] = true;
            game.grid[3, 2] = true;
            game.grid[3, 3] = true;
            game.Tick();
            Assert.IsFalse(game.grid[2, 2]);
            Assert.IsFalse(game.grid[2, 3]);
            Assert.IsFalse(game.grid[3, 2]);
            Assert.IsFalse(game.grid[3, 3]);
            Assert.IsTrue(game.grid[1, 3]);
            Assert.IsTrue(game.grid[2, 1]);
            Assert.IsTrue(game.grid[2, 4]);
            Assert.IsTrue(game.grid[3, 1]);
            Assert.IsTrue(game.grid[3, 4]);
            Assert.IsTrue(game.grid[4, 2]);
        }

    }
}


