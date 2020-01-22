using System;

namespace SAT
{
    class Program
    {
        public static int[][] generateMatrix(int numberOfRows, int numberOfColumns)
        {
            int[][] matrice = new int[numberOfColumns][];
            Random random = new Random();
            for (int i = 0; i < numberOfRows; i++)
            {
                matrice[i] = new int[numberOfColumns];
                for (int j = 0; j < numberOfColumns; j++)
                {
                    matrice[i][j] = random.Next(0, 10);
                }
            }
            return matrice;
        }

        public static void printMatrice(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(string.Join("\t", a[i]));
            }
        }

        public static int[][] generateSAT(int[][] a)
        {
            int[][] SAT = new int[a.Length][];
            for (int i = 0; i < a.Length; i++)
            {
                SAT[i] = new int[a[i].Length];
                for (int j = 0; j < a[i].Length; j++)
                {
                    SAT[i][j] = a[i][j];
                    if (i > 0)
                    {
                        SAT[i][j] += SAT[i - 1][j];
                    }
                    if (j > 0)
                    {
                        SAT[i][j] += SAT[i][j - 1];
                    }
                    if (i > 0 && j > 0)
                    {
                        SAT[i][j] -= SAT[i - 1][j - 1];
                    }

                }
            }
            return SAT;
        }

        public static int calculateSum(int[][] SAT, int row1, int column1, int row2, int column2)
        {
            int sum = SAT[row2][column2];
            if (row1 > 0)
            {
                sum += SAT[row1 - 1][column2];
            }
            if (column1 > 0)
            {
                sum += SAT[row2][column1 - 1];
            }
            if (column1 > 0 && row1 > 0)
            {
                sum -= SAT[row1 - 1][column1 - 1];
            }
            return sum;
        }

        public static int calculateSumByIteration(int[][] matrice, int row1, int column1, int row2, int column2)
        {
            int sum = 0;
            for (int i = row1; i <= row2; i++)
            {
                for (int j = column1; j <= column2; j++)
                {
                    sum += matrice[i][j];
                }
            }
            return sum;
        }

        public static Tuple<Point, Point>[] generateCoordinates()
        {
            Random r = new Random();
            Tuple<Point, Point>[] coordinates = new Tuple<Point, Point>[100000];
            for (int i = 0; i < coordinates.Length; i++)
            {
                Point point1 = new Point(r.Next(0, 980), r.Next(0, 980));
                Point point2 = new Point(r.Next(point1.x + 20, 1000), r.Next(point1.y + 20, 1000));
                coordinates[i] = new Tuple<Point, Point>(point1, point2);
            }
            return coordinates;
        }

        public static string calculateSATTime(int[][] matrix, Tuple<Point, Point>[] Coordinates)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (var pair in Coordinates)
            {
                calculateSum(matrix, pair.Item1.x, pair.Item1.y, pair.Item2.x, pair.Item2.y);
            }
            watch.Stop();
            return watch.ElapsedMilliseconds.ToString();
        }

        public static string calculateIterationTime(int[][] matrix, Tuple<Point, Point>[] Coordinates)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (var pair in Coordinates)
            {
                calculateSumByIteration(matrix, pair.Item1.x, pair.Item1.y, pair.Item2.x, pair.Item2.y);
            }
            watch.Stop();
            return watch.ElapsedMilliseconds.ToString();
        }

        public static void Main(string[] args)
        {
            int[][] matrix = generateMatrix(1000, 1000);
            //printMatrice(matrix);
            int[][] SAT = generateSAT(matrix);
            int sum = calculateSum(SAT, 0, 0, 6, 8);
            Console.WriteLine("Suma elementów podmatrycy (0,0,6,8) wynosi: " + sum);
    
            //w matrycy 1000 na 1000 policz i wydrukuj podsumy 100 podmacierzy ro rozmiarach nie mniejszych niż 20 na 20
            Tuple<Point, Point>[] coordinates = generateCoordinates();
            
            //policz i wydrukuj ile czau zajelo wykonanie tych operacji stosując algorytm SAT,
            Console.WriteLine("Time to calculate matrices using SAT is " + calculateSATTime(matrix, coordinates) + "ms");
            
            //następnie policz ile czasu zajelo to przy standardowym zliczaniu elementow 
            Console.WriteLine("Time to calculate matrices using iteration is " + calculateIterationTime(matrix, coordinates) + "ms");
            Console.ReadKey();
        }
    }

    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        
        public Point(int x1, int y1)
        {
            x = x1;
            y = y1;
        }
    }
}
