

namespace NetWorkAnalysisHW2
{
    class RandomGraph:NetworkGraph
    {
        public RandomGraph(ScaleFreeGraph sfGraph) : base(sfGraph.GetNonZeroDegreeVeticies())
        {
            //this.ConnectionsMatrix = sfGraph.ConnectionsMatrix;
            Probability = (sfGraph.CurrentGraphDegree/(double)2)/ (MaxVerticies * (MaxVerticies - 1) / (double)2);
          
        }

        public void ConnectionFunction()
        {
            for (int i = 0; i < MaxVerticies; i++)
                for (int j = 0; j < MaxVerticies; j++)
                    ConnectionsMatrix[i, j] = false;
            for (int row = 0; row < MaxVerticies; row++)
                for (int column = 0; column < MaxVerticies; column++)
                {
                    double draw = Rand.NextDouble();
                    if (Probability > draw)
                    {
                        ConnectionsMatrix[row, column] = true;
                        ConnectionsMatrix[column, row] = true;
                    }
                        
                    //Console.WriteLine("Row {0} Column {1} state {2}", row, column, ConnectionsMatrix[row, column]);
                }
            //  Console.WriteLine("Row {0}", row);  
        }
    }
}
