using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace NetWorkAnalysisHW2
{
     class NetworkGraph
    {
        private List<int> _columnIndexes;
        internal bool[,] ConnectionsMatrix { get; set; }
        internal int MaxVerticies { get; set; }
        protected Random Rand;
        protected double Probability { get; set; }
        private int[] _degreeDestribution;
        private Matrix<float> _connMatrix;

        public NetworkGraph(int n)
        {
            this.MaxVerticies = n;
            _connMatrix = Matrix<float>.Build.Dense(MaxVerticies, MaxVerticies, 0);
            ConnectionsMatrix = new bool[MaxVerticies, MaxVerticies];
            Rand = new Random();
            _columnIndexes=new List<int>(MaxVerticies);
            for (int i = 0; i < MaxVerticies; i++)
                _columnIndexes.Add(i);
            _degreeDestribution = new int[MaxVerticies];
        }

         public override string ToString()
        {
            String toPajek = "*Vertices " + MaxVerticies + "\n*Edges\n";
            for (int i = 0; i < MaxVerticies; i++)
            {
                for (int j = i+1; j < MaxVerticies; j++)
                {
                    if (ConnectionsMatrix[i, j] == true)
                        toPajek = toPajek + (i+1) + " " + (j+1) + "\n";
                }
            }
            //File.OpenWrite(@"C:\Users\Michael\Desktop\NetWorkAnalysisHW2\NetWorkAnalysisHW2\");
            //File.WriteAllText(@"C:\Users\Michael\Desktop\NetWorkAnalysisHW2\NetWorkAnalysisHW2\GraphInit.txt", toPajek);
            return toPajek;
        }

        internal int GetVericleDegree(int row)
        {
            int degree=0;
            for (int i = 0; i < MaxVerticies; i++)
                if (ConnectionsMatrix[row, i])
                    degree++;
            return degree;
        }

         private int GetColumnDegree(int column)
         {
             int colDegree = 0;
             for (int i = 0; i < MaxVerticies; i++)
                 if (ConnectionsMatrix[i, column])
                     colDegree++;
             return colDegree;
         }

         internal int GetGraphDegree()
        {
            int connection = 0;
            for(int i= 0;i<MaxVerticies;i++)
                for(int j = 0; j<MaxVerticies;j++)
                    if (ConnectionsMatrix[i, j] == true)
                        connection++;
            return connection;
        }

         internal void GetDegreeDestribution()
         {
             int vertixDegree;
             for (int j = 0; j < MaxVerticies; j++)
             {
                 vertixDegree = GetVericleDegree(j);
                 _degreeDestribution[vertixDegree]++;
             }
         }

         public String DDtoText()
         {
             String toText = "Degree Count\n";
             for (int i = 0; i < MaxVerticies; i++)
                 //if (DegreeDestribution[i] != 0)
                     toText += _degreeDestribution[i] + "\n";
             return toText;
         }

         public String DDtoIndexes()
         {
             String toText = "Indexes\n";
             for (int i = 0; i < MaxVerticies; i++)
                 //if (DegreeDestribution[i] != 0)
                     toText += i + "\n";
             return toText;

         }

         private float SumOfColumn(int col)
         {
             float sum = 0;
             for (int i = 0; i > MaxVerticies; i++)
                 sum += _connMatrix[i, col];
             return sum;
         }
         public String ConnMatrixToMarkov()
         {
             String output = "*Vertices "+MaxVerticies+"\n";
             for (int i = 0; i < MaxVerticies; i++)
                 ConnectionsMatrix[i, i] = true;
             for(int i = 0 ; i< MaxVerticies ;i++)
                 for (int j = 0; j < MaxVerticies; j++)
                 {
                     if (ConnectionsMatrix[i, j])
                         _connMatrix[i, j] = (float)1/GetColumnDegree(j);
                 }
             _connMatrix = _connMatrix.Power(2);
             for (int i = 0; i < MaxVerticies; i++)
             {
                 double sum = SumOfColumn(i);
                 for (int j = 0; j < MaxVerticies; j++)
                 {
                     _connMatrix[j, i] = (float)(Math.Pow(_connMatrix[j, i], 2))/(float)Math.Pow(sum, 2);
                 }
             }
             bool []inCluster = new bool[MaxVerticies];
             for (int i = 0; i < _columnIndexes.Count; i++) //counter
             {
                 int j = _columnIndexes[i];//row//cluster num
                 
                      for (int k = 0; k < MaxVerticies; k++)//column
                     {
                         if (_connMatrix[j, k] > 0 && inCluster[k]==false)
                         {
                             output += (j + 1) + "\n";
                             _columnIndexes.Remove(k);
                             inCluster[k] = true;
                         }
                     }     
             }
                 
           return output;
         }

         internal int GetNonZeroDegreeVeticies()
         {
             int nonZero = 0;
             for (int i = 0; i < MaxVerticies; i++)
                 if (GetVericleDegree(i) > 0)
                     nonZero++;
             return nonZero;
         }
    }
}
