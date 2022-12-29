using System;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private Color _color;
    private readonly string _name;
    private int _place;
    private int _steps;
    private int _bonuses;
    private int _fines;

    public Color Color => _color;
    public string Name => _name;

    public Player(string name, string color)
    {
        _name = name;
        _steps = 0;
        _bonuses = 0;
        _fines = 0;
        _place = 0;
        
        switch(color)
        {
            case ("Blue"):
                {
                    _color = new(0, 0, 1, 0);
                    break;
                }
            case ("Red"):
                {
                    _color = new(1, 0, 0, 0);
                    break;
                }
            case ("Yellow"):
                {
                    _color = new(1, 1, 0, 0);
                    break;
                }
            case ("Green"):
                {
                    _color = new(0, 1, 0, 0);
                    break;
                }
                default:
                {
                    throw new Exception("invalid color");
                }
        }
    }

    public (string,List<int>) ShowStats()
    {
        List<int> stats = new()
        {
            _place,
            _steps,
            _bonuses,
            _fines
        };

        return (_name, stats);
    }

    public void SetPlace(int value)
    {
        if(value > 0)
        {
            _place = value;
        }
    }

    public void AddSteps(RockType type)
    {
        switch(type)
        {
            case (RockType.Grey):
                {
                    _steps++;
                    break;
                }
            case (RockType.Red):
                {
                    _fines++;
                    break;
                }
            case (RockType.Blue):
                {
                    _bonuses++;
                    break;
                }
        }
        
    }
}
