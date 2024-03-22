namespace AntAlgorithm
{
    public partial class Form1 : Form
    {
        readonly List<Point> townsList = [];  // список координат городов
        bool isWayCreated = false;      // проверка на заполненность поля, чтобы нельзя было вставлять после алгоритма 

        public Form1()
        {
            InitializeComponent();
        }

        private void drawPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (isWayCreated)
                Reset();

            townsList.Add(e.Location);  // добавляем город в список
            DrawNode(e);                // рисуем узел на этом месте
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (isWayCreated)
                return;

            if (!double.TryParse(aTextBox.Text, out double a) ||
                !double.TryParse(bTextBox.Text, out double b) ||
                !double.TryParse(qTextBox.Text, out double q) ||
                !double.TryParse(pTextBox.Text, out double p) ||
                !double.TryParse(startingPheramoneTextBox.Text, out double startingPheramone))
            {
                MessageBox.Show("Введены некорректные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (p <= 0 || p >= 1)
            {
                MessageBox.Show("Испарение должно быть в пределах от 0 до 1.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (a <= 0 || b <= 0 || q <= 0)
            {
                MessageBox.Show("Значения должны быть положительные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<int> shortestRoad = AntAlgorithm.FindShortestRoad(a, b, q, p, startingPheramone, townsList);   // запуск алгоритма и получение итогового графа

            roadLengthTextBox.Text = $"{shortestRoad[0]}px";

            DrawShortestRoad(shortestRoad[1..], Color.Green, 3f);   // по полученному графу чертим самый короткий маршрут

            isWayCreated = true;
        }

        private void ClearField()
        {
            Graphics g = drawPanel.CreateGraphics();
            g.Clear(Color.White);
        }

        private void DrawNode(MouseEventArgs e)
        {
            int radius = 15;

            Graphics g = drawPanel.CreateGraphics();
            g.FillEllipse(Brushes.Green, e.X - radius, e.Y - radius, radius * 2, radius * 2);
        }

        private void DrawShortestRoad(List<int> pathNodes, Color color, float width)
        {
            if (pathNodes.Count < 2)
                return;

            Graphics g = drawPanel.CreateGraphics();

            for (int i = 0; i < pathNodes.Count - 1; i++)
            {
                int startingTown = pathNodes[i];
                int endTown = pathNodes[i + 1];

                Point startingPoint = townsList[startingTown];
                Point endPoint = townsList[endTown];

                g.DrawLine(new Pen(color, width), startingPoint, endPoint);
            }

            int lastTown = pathNodes[^1];
            int firstTown = pathNodes[0];

            // прочертить линию из финальной точки в начальную
            g.DrawLine(new Pen(color, width), townsList[lastTown], townsList[firstTown]);
        }

        private void Reset()
        {
            isWayCreated = false;
            townsList.Clear();      // стираем список городов
            ClearField();           // очищаем поле
        }
    }
}
