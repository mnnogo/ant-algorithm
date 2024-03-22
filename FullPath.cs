namespace AntAlgorithm
{
    internal struct FullPath
    {
        public List<int> RoadList { get; }
        public double TotalLength { get; }

        public FullPath(List<int> roadList, double totalLength)
        {
            RoadList = roadList;
            TotalLength = totalLength;
        }
    }
}
