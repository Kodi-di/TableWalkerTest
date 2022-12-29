using UnityEngine;
using UnityEngine.Events;

public class Rock : MonoBehaviour
{
    private const string _tagDrag = "Draggable";

    [SerializeField] private int _rockNumber;
    [SerializeField] private RockType _type;

    public event UnityAction<Rock> IsStepOn;

    public int RockNumber => _rockNumber;
    public RockType Type => _type;

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(_tagDrag))
        {
            IsStepOn?.Invoke(this);
        }
    }

}

public enum RockType
{
    Blue,
    Red,
    Grey
}
