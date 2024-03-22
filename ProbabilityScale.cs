namespace AntAlgorithm
{
    internal class ProbabilityScale
    {
        private readonly Random _rand = new();
        private readonly double[] _probabilities;

        public ProbabilityScale(double[] probabilities)
        {
            if (probabilities.Sum() < 0.9999999 || probabilities.Sum() > 1.00000001)
                throw new ArgumentException($"Сумма всех вероятностей не равна единице ({probabilities.Sum()})");

            _probabilities = probabilities;
        }

        public int GetRandomNumberIndex()
        {
            double randNum = _rand.NextDouble();
            double sum = 0;
            for (int i = 0; i < _probabilities.Length; i++)
            {
                sum += _probabilities[i];
                if (randNum < sum)
                    return i;
            }

            // если не найдено, то возвращаем последнее число
            return _probabilities.Length - 1;
        }
    }
}
