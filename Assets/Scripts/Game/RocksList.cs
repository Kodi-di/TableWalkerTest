using System.Collections.Generic;
using UnityEngine;

public class RocksList : MonoBehaviour
{
    [SerializeField] private List<Rock> _rocks;

    private List<Rock> _currentsRocks;

    public List<Rock> CurrentsRocks => _currentsRocks;
    public List<Rock> Rocks => _rocks;

    private void Start()
    {
        _rocks.Sort((x, y) => x.RockNumber - y.RockNumber);
    }

    public void Init(int count)
    {
        _currentsRocks = new(count);

        for(int i = 0; i < count; i++)
        {
            _currentsRocks.Add(_rocks[0]);
        }
    }
}
