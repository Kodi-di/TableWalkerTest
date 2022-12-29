using UnityEngine;
using TMPro;

public class Row : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _place;
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _steps;
    [SerializeField] TextMeshProUGUI _bonuses;
    [SerializeField] TextMeshProUGUI _fines;

    public void SetValues(int place, string name, int steps, int bonuses, int fines)
    {
        _place.text = place.ToString();
        _name.text = name.ToString();
        _steps.text = steps.ToString();
        _bonuses.text = bonuses.ToString();
        _fines.text = fines.ToString();
    }
}
