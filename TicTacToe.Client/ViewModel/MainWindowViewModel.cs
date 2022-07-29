using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace TicTacToe.Client.ViewModel
{
    public partial class TicTacToeItem : ObservableObject
    {
        [ObservableProperty]
        private int _location;
        [ObservableProperty]
        private char _item;
    }

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public int _boardSize = 3;

        public int BoardSize
        {
            get => _boardSize;
            set
            {
                if (_boardSize != value)
                {
                    if (value < 3)
                    {
                        _boardSize = 3;
                    }
                    else if(value > 20)
                    {
                        _boardSize = 20;
                    }
                    else
                    {
                        _boardSize = value;
                    }
                    CreateBoard();
                    OnPropertyChanged(nameof(BoardSize));
                }
            }
        }

        public string CurrentPlayer
        {
            get
            {
                return $"Active Player: {(_game.ActivePlayer ? _game.YValue : _game.XValue)}";
            }
        }

        public ICommand ButtonClicked { get; set; }

        public ObservableCollection<TicTacToeItem> Board { get; set; } = new();

        private TicTacToeGame _game;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CreateBoard()
        {
            _game = new TicTacToeGame(BoardSize);
            UpdateBoard();
        }

        private void UpdateBoard()
        {
            int i = 0;
            Board.Clear();
            foreach (var entry in _game.Board)
            {
                Board.Add(new TicTacToeItem()
                {
                    Location = i++,
                    Item = entry
                });
            }
            OnPropertyChanged(nameof(CurrentPlayer));
        }

        public MainWindowViewModel()
        {
            CreateBoard();

            ButtonClicked = new RelayCommand<int>(OnButtonClicked);
        }

        private void OnButtonClicked(int location)
        {
            int x = (int)Math.Floor((double)(location / BoardSize));
            int y = (int)Math.Floor((double)(location % BoardSize));
            var result = _game.SetXYValue(x, y);
            switch(result)
            {
                case TicTacToeSetResult.Success:
                    UpdateBoard();
                    if(_game.TryGetWinner(out var winner))
                    {
                        switch (winner)
                        {
                            case TicTacToeResult.Tie:
                                MessageBox.Show($"YOU BOTH CAN'T PLAY", "TICTACFUCKED");
                                break;

                            case TicTacToeResult.XWon:
                            case TicTacToeResult.YWon:
                                MessageBox.Show($"{(winner == TicTacToeResult.YWon ? _game.YValue : _game.XValue)} WON YOU FATASS", "TICTACFUCKED");
                                break;
                        }
                        CreateBoard();
                    }
                    return;
                case TicTacToeSetResult.AlreadyPlaced:
                    MessageBox.Show($"L2P TicTacToe, idiot!", "TICTACFUCKED");
                    break;
                default:
                    break;
            }
        }
    }
}
