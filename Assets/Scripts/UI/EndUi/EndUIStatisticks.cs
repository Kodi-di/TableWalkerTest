using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUIStatisticks : MonoBehaviour
{
    [SerializeField] GameObject _row;
    [SerializeField] Transform _content;
    [SerializeField] Button _exit;
    [SerializeField] Button _repeat;

    private void Start()
    {
        _exit.onClick.AddListener(Exit);
        _repeat.onClick.AddListener(Repeat);
    }

    public void InitEndStatistick(List<Piece> pieces)
    {
        pieces.Sort((x, y) => x.Stats.Item2[0] - y.Stats.Item2[0]);

        foreach (var piece in pieces)
        {
            var row = Instantiate(_row, _content);
            var stat = piece.Stats;
            row.GetComponent<Row>().SetValues(stat.Item2[0], stat.Item1, stat.Item2[1], stat.Item2[2], stat.Item2[3]);
        }
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void Repeat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
