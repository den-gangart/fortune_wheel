using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelGenerator : MonoBehaviour
{

    [SerializeField] private UIController uIController;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private Transform rotationElements;

    public float rotationMaxSpeed;
    public float rotationMinSpeed;
    public int revolutionCount;

    private List<int> _wheelValues;
    private const int COUNT_OF_PIE = 16;
    private const int CIRCLE_DEGREES = 360;

    private int minValue = 10;
    private int maxValue = 1000;
    private float angleStep = 22.5f;

    private float speed;
    private bool _spin;
    private float endAngle;
    private float rotationAngle;
    private float currentAngle;
    private int winValue;
    private int prevIndex;
    private int randomIndex;

    private SpinTicker spinTicker;

    // Start is called before the first frame update
    void Start()
    {
        _spin = false;
        GenerateValues();
        spinTicker = rotationElements.GetComponent<SpinTicker>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_spin)
        {
            rotationAngle = -speed * Time.deltaTime;
            currentAngle += rotationAngle;
            rotationElements.Rotate(0, 0, rotationAngle);

            float angleDifference = Mathf.Abs(endAngle - currentAngle);

            if (angleDifference < rotationMaxSpeed && speed > rotationMinSpeed)
                speed = angleDifference;

            if (currentAngle <= endAngle)
            {
                OnFinishSpin();
                _spin = false;
            }
        }
    }

    private void OnFinishSpin()
    {
        scoreController.AddMoney(winValue);
        spinTicker.EndSpin();
        uIController.EnableSpin();
    }

    private void GenerateValues()
    {
        _wheelValues = new List<int>();

        for(int i = 0; i < COUNT_OF_PIE; i++)
        {
            int value = 0;
            while(value == 0)
            {
                value = Random.Range(minValue, maxValue+1);
                for (int j = 0; j < _wheelValues.Count; j++)
                    if (_wheelValues[j] - value < 10 && _wheelValues[j] - value > -10)
                    {
                        value = 0;
                        break;
                    }
            }
            _wheelValues.Add(value);
        }

        for (int i = 0; i < _wheelValues.Count; i++)
            _wheelValues[i] *= 100;

        uIController.InitLabelList(_wheelValues);
    }

    public void StartSpin()
    {
        prevIndex += randomIndex;

        randomIndex = Random.Range(0, _wheelValues.Count);
        winValue = _wheelValues[randomIndex];
        speed = rotationMaxSpeed;

        currentAngle = endAngle;

        if (endAngle != 0)
        {
            randomIndex += COUNT_OF_PIE - prevIndex;

            //Reduce endAngle and currentAngle
            endAngle += Mathf.Floor(-endAngle / CIRCLE_DEGREES) * CIRCLE_DEGREES;
            currentAngle += Mathf.Floor(-currentAngle / CIRCLE_DEGREES) * CIRCLE_DEGREES;
        }

        endAngle +=-(angleStep*randomIndex+ CIRCLE_DEGREES * revolutionCount);
        _spin = true;

        spinTicker.StartSpin();
    }
}
