using UnityEngine;
using TMPro;

namespace Mikabrytu.BJ3.View
{
    public class TimeLoopDisplayView : MonoBehaviour, IDisplay
    {
        private TextMeshProUGUI time;

        private void Start()
        {
            time = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateDisplay(float value)
        {
            if (time != null)
                time.text = $"Time Remaining {(int)value}s";
        }
    }
}
