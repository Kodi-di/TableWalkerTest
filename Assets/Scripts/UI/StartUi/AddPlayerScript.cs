using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(Button))]
public class AddPlayerScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField _playerName;
    [SerializeField] private TMP_Dropdown _colorSelection;
    [SerializeField] private Transform _playersTable;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private List<Piece> _pieces;
    [SerializeField] private Transform _gameField;
    [SerializeField] private Button _startGame;

    private Button _addPlayer;
    private List<Piece> _currentPiece = new();
    private int _itter = 1;

    private void Start()
    {
        _addPlayer = GetComponent<Button>();
        _addPlayer.onClick.AddListener(AddPlayer);
        _startGame.onClick.AddListener(StartGame);
    }

    private void AddPlayer()
    {
        if(_playerName.text == "")
        {
            return;
        }
        Player player = new(_playerName.text, _colorSelection.captionText.text);
        TextMeshProUGUI player_data = Instantiate(_playerPrefab, _playersTable).GetComponent<TextMeshProUGUI>();
        player_data.text = _itter.ToString() + ". " + player.Name + " chip color: " + _colorSelection.captionText.text;

        foreach (var piece in _pieces)
        {

            if (player.Color == piece.PieceColor)
            {
                _currentPiece.Add(piece);
                piece.InitPiece(player);
            }
        }

        _colorSelection.options.RemoveAt(_colorSelection.value);
        _colorSelection.value++;
        if(_colorSelection.options.Count == 0)
        {
            _colorSelection.captionText.text = "None";
            _addPlayer.enabled = false;
        }

        _playerName.text = "";
        _itter++;
    }

    private void StartGame()
    {
        if(_currentPiece.Count == 0)
        {
            return;
        }

        var game = _gameField.GetComponent<Game>();
        game.enabled = true;
        game.InitGame(_currentPiece);
        foreach(var piece in _pieces)
        {
            if(piece.Player == null)
            {
                piece.DestroyPiece();
            }
        }
    }

}
