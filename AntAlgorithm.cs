namespace AntAlgorithm
{
    internal static class AntAlgorithm
    {
        private static List<Point> _townsList = [];

        /// <summary>
        /// Возвращает список, где первое число - лучшая длина пути, остальные - сам путь.
        /// </summary>
        public static List<int> FindShortestRoad(double a, double b, double q, double p, double startingPheramone, List<Point> townsList)
        {
            if (townsList.Count == 1)
                return [0];

            _townsList = townsList;

            var graph = CreateOptimalGraph(a, b, q, p, startingPheramone);

            List<int> shortestRoad = FindShortestRoadFromGraph(graph);  
            int shortestLength = (int)FindLengthFromRoad(shortestRoad, graph);            

            return [shortestLength, ..shortestRoad];
        }

        private static List<int> FindShortestRoadFromGraph(Path[,] graph)
        {
            int townsAmount = _townsList.Count;

            // начальную точку выбираем 0-ой город (разницы нет)
            List<int> shortestRoad = [0];
            List<int> unvisitedTowns = Enumerable.Range(1, townsAmount - 1).ToList();

            int currentTown = 0;

            while (unvisitedTowns.Count > 0)
            {
                int newDestination = -1;
                double maxPheramoneValue = double.MinValue;

                // находим путь с текущего города до другого с максимальным ферамоном
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (!unvisitedTowns.Contains(i))
                        continue;

                    if (graph[currentTown, i].Pheramone > maxPheramoneValue)
                    {
                        maxPheramoneValue = graph[currentTown, i].Pheramone;
                        newDestination = i;
                    }
                }

                shortestRoad.Add(newDestination);
                unvisitedTowns.Remove(newDestination);

                currentTown = newDestination;
            }

            return shortestRoad;
        }

        private static double FindLengthFromRoad(List<int> road, Path[,] graph)
        {
            double totalLength = 0;

            for (int i = 0; i < road.Count - 1; i++)
            {
                int startingTown = road[i];
                int endTown = road[i + 1];

                double length = graph[startingTown, endTown].PathLength;

                totalLength += length;
            }

            // прибавляем возвращение в начальную
            totalLength += graph[road[^1], road[0]].PathLength;

            return totalLength;
        }

        private static Path[,] CreateOptimalGraph(double a, double b, double q, double p, double startingPheramone)
        {
            var graph = CreateGraph(startingPheramone); // создаем начальный граф с расстоянием и количеством ферамона между узлами

            int townsAmount = _townsList.Count;

            for (int iter = 0; iter < 50000; iter++)
            {
                List<FullPath> fullPaths = [];

                // запускаем по одному муравью с каждой вершины
                for (int startingTown = 0; startingTown < townsAmount; startingTown++)
                {
                    // список непосещенных городов, в которые можно пойти (изначально все)
                    List<int> availableTowns = Enumerable.Range(0, townsAmount).ToList();
                    availableTowns.Remove(startingTown);

                    List<int> antPath = [];    // путь, пройденный муравьем
                    antPath.Add(startingTown); // отправная точка

                    int currentTown = startingTown;

                    // пока муравей не прошел все города
                    while (availableTowns.Count > 0)
                    {
                        // вычисляем суммарное "желание" муравья двинуться в каждый город
                        double sumWishToMove = 0;
                        double[] wishToMoveTo = new double[townsAmount];
                        for (int townMoveTo = 0; townMoveTo < townsAmount; townMoveTo++)
                        {
                            if (!availableTowns.Contains(townMoveTo)) // если город уже посетили
                                continue;

                            wishToMoveTo[townMoveTo] = Math.Pow(graph[currentTown, townMoveTo].Pheramone, a) *
                                Math.Pow(1 / graph[currentTown, townMoveTo].PathLength, b);

                            sumWishToMove += wishToMoveTo[townMoveTo];
                        }

                        // вычисляем вероятности муравья пойти в каждый город делением желания на суммарное желание
                        double[] probabilities = new double[townsAmount];
                        for (int townMoveTo = 0; townMoveTo < townsAmount; townMoveTo++)
                        {
                            if (!availableTowns.Contains(townMoveTo)) // если город уже посетили
                                continue;

                            probabilities[townMoveTo] = wishToMoveTo[townMoveTo] / sumWishToMove;
                        }

                        // по шкале вероятности совмещаем все города и случайно выбираем один из них
                        ProbabilityScale probabilityScale = new(probabilities);
                        int chosenTownIndex = probabilityScale.GetRandomNumberIndex();

                        // перемещаемся в новый город и убираем его из доступных, добавляем его в путь муравья
                        availableTowns.Remove(chosenTownIndex);
                        antPath.Add(chosenTownIndex);

                        currentTown = chosenTownIndex;
                    }

                    // после того как прошел все города, посчитать длину пути
                    double totalLength = FindTotalLength(antPath, graph);

                    // добавляем путь муравья и длину пути в общий список
                    fullPaths.Add(new FullPath(antPath, totalLength));
                }

                // записать все дельты ферамона в массив
                double[,] pheramoneDeltas = new double[townsAmount, townsAmount];
                for (int i = 0; i < fullPaths.Count; i++)  // по каждому пути
                {
                    for (int j = 0; j < fullPaths[i].RoadList.Count - 1; j++)  // по каждой дороге пути, кроме последнего
                    {
                        int startTown = fullPaths[i].RoadList[j];
                        int endTown = fullPaths[i].RoadList[j + 1];

                        double pheramoneDelta = q / fullPaths[i].TotalLength;

                        // добавить ферамон из первого города в последний и наоборот
                        pheramoneDeltas[startTown, endTown] += pheramoneDelta;
                        pheramoneDeltas[endTown, startTown] += pheramoneDelta;
                    }
                }

                // добавить ферамон в основной граф 
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    for (int j = 0; j < graph.GetLength(1); j++)
                    {
                        graph[i, j].Pheramone = p * graph[i, j].Pheramone + pheramoneDeltas[i, j];
                    }
                }
            }

            return graph;
        }

        private static double FindTotalLength(List<int> antPath, Path[,] graph)
        {
            double totalLength = 0;

            for (int i = 0; i < antPath.Count - 1; i++)
            {
                int startingTown = antPath[i];
                int townToMoveTo = antPath[i + 1];

                double length = graph[startingTown, townToMoveTo].PathLength;

                totalLength += length;
            }

            totalLength += graph[antPath[^1], antPath[0]].PathLength;

            return totalLength;
        }

        private static Path[,] CreateGraph(double startingPheramone)
        {
            int townsAmount = _townsList.Count;
            Path[,] result = new Path[townsAmount, townsAmount];

            for (int i = 0; i < townsAmount; i++)
            {
                for (int j = 0; j < townsAmount; j++)
                {
                    // заполняем граф расстояниями и начальным значением ферамона 
                    result[i, j] = new Path(
                        FindLengthBetween(_townsList[i], _townsList[j]),
                        startingPheramone
                        );
                }
            }

            return result;
        }

        private static double FindLengthBetween(Point point1, Point point2)
        {
            return Math.Sqrt((point2.X - point1.X) * (point2.X - point1.X) + (point2.Y - point1.Y) * (point2.Y - point1.Y));
        }
    }
}
