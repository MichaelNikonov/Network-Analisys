/**
 * Network Analysis HomeWork implementation,by Michael Nikonov
 * This code implements the generation and Markov clustering algorithm for 3 kinds of graphs,1261 vertices each : 
 *  -Random Graph
 *  -Random Graph with degree Destribution
 *  -Scale Freee Graph
 * Also code generatese *.net files,and *.clu files, for each kind of graph,that used by Pajek for graph visualization.
 * **/


using System.IO;


namespace NetWorkAnalysisHW2
{
    class Program
    {
        public static void Main(string[] args)
        {
  
            ScaleFreeGraph sfGraph = new ScaleFreeGraph(1261);
            sfGraph.ConnectionFunction();
            sfGraph.GetDegreeDestribution();
            RandomGraph rGraph = new RandomGraph(sfGraph);
            RgDegreeDistribution rgDegree = new RgDegreeDistribution(sfGraph);
           // File.WriteAllText("PrimeGraph.net", nGraph.ToString());
           // File.WriteAllText("PrimeCount.txt", nGraph.DDtoText());
           // File.WriteAllText("PrimeIndexes.txt", nGraph.DDtoIndexes());
            
            File.WriteAllText("ScaleFreeGraph.net", sfGraph.ToString());
            File.WriteAllText("ScaleFreeCount.txt", sfGraph.DDtoText());
            //File.WriteAllText("ScaleFreeIndexes.txt", sfGraph.DDtoIndexes());
            File.WriteAllText("ScaleFreeClus.clu", sfGraph.ConnMatrixToMarkov());
            rGraph.ConnectionFunction();
            rGraph.GetDegreeDestribution();
            File.WriteAllText("RandomGraph.net", rGraph.ToString());
            File.WriteAllText("RandomCount.txt", rGraph.DDtoText());
            //File.WriteAllText("RandomIndexes.txt", rGraph.DDtoIndexes());
            File.WriteAllText("RandomClus.clu", rGraph.ConnMatrixToMarkov());
            rgDegree.ConnectionFunction();
            rgDegree.GetDegreeDestribution();
            File.WriteAllText("RGDegree.net", rgDegree.ToString());
            File.WriteAllText("RGDegreeCount.txt", rgDegree.DDtoText());
            //File.WriteAllText("RGDegreeIndexes.txt", rgDegree.DDtoIndexes());
            File.WriteAllText("RgDegreeClu.clu", rgDegree.ConnMatrixToMarkov());
        }
    }
}
