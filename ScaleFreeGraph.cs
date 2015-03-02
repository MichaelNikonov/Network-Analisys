namespace NetWorkAnalysisHW2
{
    class ScaleFreeGraph:NetworkGraph
    {
        internal int CurrentGraphDegree { get; private set; }

        public ScaleFreeGraph(int n) : base(n)
        {
            for (int i = 0; i < 1; i++)
            {
                int row = Rand.Next(0, MaxVerticies);
                int column = Rand.Next(0, MaxVerticies);
                if (row != column && ConnectionsMatrix[row, column] == false)
                {

                    ConnectionsMatrix[row, column] = true;
                    ConnectionsMatrix[column, row] = true;
                }
                else
                    i--;
            }

            for (int i = 0; i < 5000; i++)
            {
                int row = Rand.Next(0, MaxVerticies);
                int column = Rand.Next(0, MaxVerticies);
                if ((row != column) && (GetVericleDegree(row) > 0) && (ConnectionsMatrix[row, column] == false))
                {

                    ConnectionsMatrix[row, column] = true;
                    ConnectionsMatrix[column, row] = true;
                }
                else
                    i--;
            }
            CurrentGraphDegree = GetGraphDegree();
        }

         public void ConnectionFunction()
        {
             for (int row = 0; row < MaxVerticies; row++)
                 for (int column = 0; column < MaxVerticies; column++)
                 {
                     
                     Probability = ((double) GetVericleDegree(row)/CurrentGraphDegree)*2.3;
                     double draw = Rand.NextDouble();
                     if (Probability > draw)
                     {
                         ConnectionsMatrix[row, column] = true;
                         ConnectionsMatrix[column, row] = true;
                         CurrentGraphDegree = CurrentGraphDegree + 2;
                     }

                     //Console.WriteLine("Row {0} Column {1} state {2}", row, column, ConnectionsMatrix[row, column]);
                 }
             //  Console.WriteLine("Row {0}", row);  
        }
    }
}
