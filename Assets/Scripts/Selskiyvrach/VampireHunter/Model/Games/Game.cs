﻿namespace Selskiyvrach.VampireHunter.Model.Games
{
    public class Game 
    {
        public Game(GameplayState gameplayState) => 
            gameplayState.Enter();
    }
}