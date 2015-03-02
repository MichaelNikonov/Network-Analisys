using System.Collections.Generic;

namespace NetWorkAnalysisHW2
{
    class RgDegreeDistribution:NetworkGraph
    {
        private int[] VertixValue;

        private List<int> Indexes;
        private int AverageDegree;
        private int DegreeSum;
        public RgDegreeDistribution(ScaleFreeGraph sfGraph) : base(sfGraph.GetNonZeroDegreeVeticies())
        {
            //this.ConnectionsMatrix = sfGraph.ConnectionsMatrix;
            VertixValue = new int[MaxVerticies];
            Indexes = new List<int>(MaxVerticies);
            //ColumnsLeft = new List<int>(n);
            AverageDegree = (sfGraph.CurrentGraphDegree)/MaxVerticies;
            for (int i = 0; i < MaxVerticies; i++)
            {
                VertixValue[i] = AverageDegree;
                Indexes.Add(i);
            }
        }
        public void ConnectionFunction()
        {
            while (IsLeftWhatToConnect())
            {
                int row = Rand.Next(0, Indexes.Count);
                int column = Rand.Next(0, Indexes.Count);
                VertixValue[Indexes[row]] = VertixValue[Indexes[row]] - 1;
                VertixValue[Indexes[column]] = VertixValue[Indexes[column]] - 1;
                ConnectionsMatrix[row, column] = true;
                ConnectionsMatrix[column, row] = true;
                  for (int i = 0; i < Indexes.Count; i++)
                      if (VertixValue[Indexes[i]] <= 0)
                          Indexes.RemoveAt(i);
                
            }
            //Console.WriteLine("Row {0} Column {1} state {2}", row, column, ConnectionsMatrix[row, column]);
            //  Console.WriteLine("Row {0}", row);  
        }

        private bool IsLeftWhatToConnect()
        {
            for(int i=0 ; i< Indexes.Count;i++)
                for (int j = i + 1; j < Indexes.Count; j++)
                {
                    if (VertixValue[Indexes[i]] != 0 && VertixValue[Indexes[j]] != 0 && ConnectionsMatrix[Indexes[i], Indexes[j]] == false)
                        return true;
                }
            return false;
        }
    }
}
