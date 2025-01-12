using System;
using System.Collections.Generic;

namespace SQLiteApp
{
    public static class UndoManager
    {
        private static readonly Stack<UndoAction> _undoStack = new Stack<UndoAction>();
        private static bool _isUndoInProgress = false;

        public static bool CanUndo => _undoStack.Count > 0;

        public static void AddAction(string description, Action undo)
        {
            if (_isUndoInProgress) return;
            if (undo == null) throw new ArgumentNullException(nameof(undo));

            _undoStack.Push(new UndoAction(description, undo));
        }

        public static void Undo()
        {
            if (_undoStack.Count == 0)
            {
                Console.WriteLine("No actions to undo.");
                return;
            }

            var lastAction = _undoStack.Pop();
            try
            {
                _isUndoInProgress = true;
                lastAction.Undo();
                Console.WriteLine($"Action undone: {lastAction.Description}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during undo: {ex.Message}");
            }
            finally
            {
                _isUndoInProgress = false;
            }
        }

        private class UndoAction
        {
            public string Description { get; }
            public Action Undo { get; }

            public UndoAction(string description, Action undo)
            {
                Description = description;
                Undo = undo;
            }
        }
    }
}
