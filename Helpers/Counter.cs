using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class Counter
    {
        private readonly int maximumValue;
        private readonly int minimumValue;
        private readonly int step;

        public int MaximumValue => maximumValue;
        public int MinimumValue => minimumValue;
        public int Step => step;
        public int CurrentValue { get; private set; }
        public Counter(int minimumValue, int maximumValue, int step)
        {
            if (minimumValue > maximumValue)
                throw new ArgumentException(
                    "Максимальное значение не может быть меньше минимального (меньше 0 при инициализации без указания минимального значения)");
            if (step < 1)
                throw new ArgumentException(
                    "Шаг не может быть меньше еденицы");
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
            this.step = step;
            CurrentValue = MinimumValue;
        }
        public Counter(int maximumValue, int step) : this(0, maximumValue, step) { }
        public Counter(int maximumValue) : this(maximumValue, 1) { }
        public void Increase() => CurrentValue = CurrentValue >= MaximumValue ? MaximumValue : CurrentValue + Step;
        public void Decrease() => CurrentValue = CurrentValue <= MinimumValue ? MinimumValue : CurrentValue - Step;
        public void Reset() => CurrentValue = MinimumValue;
        public void SetCurrentValue(int value)
        {
            if (value % Step != 0) value /= Step;

            if (value < MinimumValue) CurrentValue = MinimumValue;
            else if (value > MaximumValue) CurrentValue = MaximumValue;
            else CurrentValue = value;
        }
    }
}
