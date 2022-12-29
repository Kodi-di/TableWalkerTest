using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] private Color _pieceColor;

    private Player _player = null;

    public (string, List<int>) Stats => _player.ShowStats();

    public Color PieceColor => _pieceColor;
    public Player Player => _player;

    public void InitPiece(Player player)
    {
        _player = player;
    }

    public void DestroyPiece()
    {
        gameObject.SetActive(false);
    }

}
