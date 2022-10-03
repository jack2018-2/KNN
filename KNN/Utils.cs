using System;

namespace ConsoleApp10
{
    public static class Utils
    {
        public static double pairDotsDistance(Dot dot1, Dot dot2) //расстояние между парой точек
        {
            var result = 0d;
            for (var i = 0; i < dot1.Signs.Count; i++)
            {
                result += (double)Math.Max(dot1.SignsWeights[i], dot2.SignsWeights[i]) * Math.Pow((double)dot1.Signs[i] - (double)dot2.Signs[i], 2);
            }
            return Math.Sqrt(result);
        }

        //public static double dotClassDistance(Dot x, Classes class1) //расстояние от точки до всех остальных точек множества
        //{
        //    double res = 0;
        //    foreach (Dot item in class1.dots)
        //    {
        //        res += Math.Pow(pairDotsDistance(x, item), 2);
        //    }
        //    return res / (class1.dots.Count - 1);
        //}

        //public static double insideClassDistance(Classes class1) //внутриклассовое расстояние
        //{
        //    double res = 0;
        //    foreach (Dot item in class1.dots)
        //    {
        //        res += dotClassDistance(item, class1);
        //    }
        //    return res / (class1.dots.Count * (class1.dots.Count - 1));
        //}

        //public static double betweenClassDistance(Classes class1, Classes class2) //расстояние между двумя классами
        //{
        //    double res = 0;
        //    foreach (Dot item1 in class1.dots)
        //    {
        //        foreach (Dot item2 in class2.dots)
        //        {
        //            res += Math.Pow(pairDotsDistance(item1, item2), 2);
        //        }
        //    }
        //    return res / (class1.dots.Count * class2.dots.Count);
        //}

        //public static double averageBetweenClassDistance(List<Classes> classes) //среднее межклассовое
        //{
        //    double res = 0;
        //    int count = 0;
        //    for (int i = 0; i < classes.Count; i++)
        //    {
        //        for (int j = i; j < classes.Count; j++)
        //        {
        //            if (i != j)
        //            {
        //                res += betweenClassDistance(classes[i], classes[j]);
        //                count++;
        //            }
        //        }
        //    }
        //    return res / count;
        //}

        //public static double averageInsideClassDistance(List<Classes> classes) //среднее внутриклассовое
        //{
        //    double res = 0;
        //    int count = 0;
        //    foreach (Classes class1 in classes)
        //    {
        //        res += insideClassDistance(class1);
        //        count++;
        //    }
        //    return res / count;
        //}

        //public static double Information(List<Classes> classes, int classNumber) //информативность
        //{
        //    return averageBetweenClassDistance(classes) / (averageInsideClassDistance(classes) * (classNumber - 1));
        //}
    }
}
