namespace AntAlgorithm
{
    public struct Path
    {
        public double PathLength;
        public double Pheramone;

        public Path(double length, double pheramone)
        {
            PathLength = length;
            Pheramone = pheramone;
        }
    }
}
