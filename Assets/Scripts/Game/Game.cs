using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private const string _tagDrag = "Draggable";
    private const string _tagUnDrag = "UnDraggable";
    private const int _finesStep = -3;

    [SerializeField] private Transform _gamePoint;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _endUI;
    [SerializeField] private GameObject _startUI;
    [SerializeField] private RocksList _rocksList;
    [SerializeField] private InGameUI _inGameUI;
    [SerializeField] private GameObject _button;

    private List<Piece> _currentPieces;
    private List<Piece> _pieces;
    private Camera _camera;
    private int _currentPiece;
    private int _place = 1;

    public bool IsGame => _currentPieces.Count != 0;

    private void Start()
    {
        _button.SetActive(true);
        _inGameUI.RollDice.AddListener(RollDice);
        _camera = Camera.allCameras[0];
        _startUI.SetActive(false);
        _camera.transform.position = _gamePoint.position;
        _camera.transform.rotation = _gamePoint.rotation;
    }

    private void StartStep()
    {
        if(IsGame)
        {
            _currentPieces[_currentPiece].GetComponent<Transform>().tag = _tagDrag;
            _inGameUI.ShowMessage(_currentPieces[_currentPiece]);
            _inGameUI.ButtonEnabed(true);

        }else
        {
            EndGame();
        }
    }

    private void RollDice()
    {
        _inGameUI.ButtonEnabed(false);

        Step(RollValue());
    }

    private void Step(int rolling)
    {
        var step = _rocksList.CurrentsRocks[_currentPiece].RockNumber;
        step += rolling;

        _inGameUI.ShowStepInfo(IsFinished(step), rolling, _currentPieces[_currentPiece]);

        _rocksList.Rocks[IsFinished(step)].IsStepOn += CheckRock;
    }

    private int RollValue()
    {
        return Random.Range(1, 7);
    }

    private void CheckRock(Rock rock)
    {
        _currentPieces[_currentPiece].Player.AddSteps(rock.Type);

        switch (rock.Type)
        {
            case (RockType.Grey):
                {
                    EndStep(rock);
                    break;
                }
            case (RockType.Blue):
                {
                    ContinueStep(rock, false);
                    break;
                }
            case (RockType.Red):
                {
                    ContinueStep(rock, true);
                    break;
                }
        }
    }

    private void ContinueStep(Rock rock, bool isRed)
    {
        rock.IsStepOn -= CheckRock;
        _rocksList.CurrentsRocks[_currentPiece] = rock;

        if(isRed)
        {
            Step(_finesStep);
            return;
        }
        _inGameUI.ShowMessage(_currentPieces[_currentPiece]);
        _inGameUI.ButtonEnabed(true);
    }

    private void EndStep(Rock rock)
    {
        _currentPieces[_currentPiece].GetComponent<Transform>().tag = _tagUnDrag;
        rock.IsStepOn -= CheckRock;
        _rocksList.CurrentsRocks[_currentPiece] = rock;

        if( rock.RockNumber == (_rocksList.Rocks.Count - 1))
        {
            EndPieceGame();
        }

        Iterator();
        StartStep();
    }

    private int IsFinished(int itter)
    {
        var value = itter < _rocksList.Rocks.Count ? itter : (_rocksList.Rocks.Count - 1);
        return value;
    }

    private void EndPieceGame()
    {
        _currentPieces[_currentPiece].Player.SetPlace(_place);
        _place++;
        _currentPieces.RemoveAt(_currentPiece);
        _rocksList.CurrentsRocks.RemoveAt(_currentPiece);
        _currentPiece--;
    }

    private void Iterator()
    {
        if(_currentPiece < (_currentPieces.Count - 1))
        {
            _currentPiece++;
        }else
        {
            _currentPiece = 0;
        }
    }

    private void EndGame()
    {
        _camera.transform.position = _startPoint.position;
        _camera.transform.rotation = _startPoint.rotation;
        _button.SetActive(false);
        _inGameUI.Clear();
        _endUI.SetActive(true);
        _endUI.GetComponent<EndUIStatisticks>().InitEndStatistick(_pieces);
    }

    public void InitGame(List<Piece> pieces)
    {
        _pieces = pieces;
        _currentPieces = new(pieces);
        _currentPiece = 0;
        _rocksList.Init(_currentPieces.Count);
        StartStep();
    }

}
