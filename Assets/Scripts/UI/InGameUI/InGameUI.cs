using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _step;
    [SerializeField] private TextMeshProUGUI _rock;
    [SerializeField] private Button _rollDice;

    public Button.ButtonClickedEvent RollDice => _rollDice.onClick;

    public void ShowStepInfo(int rock, int step, Piece piece)
    {
        _step.text = "Now it's the " + piece.Player.Name + "'s turn";
        _rock.text = "Rolled "+ step.ToString() + ", go to " + rock.ToString() + " stone ";
    }

    public void Clear()
    {
        _step.text = "";
        _rock.text = "";
    }

    public void ShowMessage(Piece piece)
    {
        _step.text = "Now it's the " + piece.Player.Name + "'s turn";
        _rock.text = "Roll the dice";
    }

    public void ButtonEnabed(bool value)
    {
        _rollDice.enabled = value;
    }

}
