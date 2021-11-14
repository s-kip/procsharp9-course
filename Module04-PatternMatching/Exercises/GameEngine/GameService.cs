using System;

namespace GameEngine
{
    public class GameService
    {
        private Player _currentMovePlayer;
        public const int MaxMoves = 128;

        public GameService(Player currentMovePlayer)
        {
            _currentMovePlayer = currentMovePlayer;
        }

        public bool ProcessCommand(CommandDTO command)
         => command switch
        {  
            null => throw new ArgumentNullException(nameof(command)),
            {PlayerSide: var p} when p != _currentMovePlayer => throw new InvalidMoveException("Invalid player side"),
            {Index: < 0} or {Index: > MaxMoves} => throw new InvalidMoveException("Invalid game index"),
            _ => Process(command.PlayerSide, (uint)command.Index, command.Move)
        };

        private bool Process(Player player, uint index, MoveType move)
        {
            Console.WriteLine($"[#{index:D3}] {player} make {move} move.");
            return true;
        }
    }
}
