using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace VizinhoMaisProximo
{

    class Program
    {
        private static int comparacoes = 0;
        public static int dist = 0;
        public static int INF = int.MaxValue;
        private String[] _nomes;
        private int[,] _distancias;
        public static int FIRST_VERTEX;
        public static int LAST_VERTEX;

        private Stack<int> stack;


        public Program(int[,] _distancias, string[] _nomes, int a , int b)
        {
            this._nomes = _nomes;
            FIRST_VERTEX = 0;
            LAST_VERTEX = _nomes.Length - 1;
            this._distancias = _distancias;
            stack = new Stack<int>();
            Analize(a, b);
        }


        public void Analize(int de, int para)
        {
            Noh resultado;

            try
            {
                resultado = CalculaCaminho(de, para);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{_nomes[de]} nao esta conectado a {_nomes[de]}");
                return;
            }

            Console.WriteLine($"{_nomes[FIRST_VERTEX]} ->");

            for (Noh temp = resultado; temp.proximo != null; temp = temp.proximo)
            {
                Console.WriteLine($"{_nomes[temp.nohAtual]} - {temp.distancia}");
                dist += temp.distancia;
            }

            int distanciaFinal = resultado.distancia;
            Console.WriteLine($"-> {_nomes[FIRST_VERTEX]}");
            Console.WriteLine($"Distancia: {dist}");
            Console.WriteLine($"Comparacoes: {comparacoes}");
        }

        private Noh CalculaCaminho(int src, int dest)
        {
            if (src == dest)
            {
                return new Noh(dest, 0, null);
            }
            ArrayList sucessores = new ArrayList();
            for (int z = FIRST_VERTEX; z <= LAST_VERTEX; z++)
            {
                if ((sucessor(src, z)) && (!stack.Contains(z)))

                {

                    sucessores.Add(z);
                }
            }
            stack.Push(src);
            Noh NohDoSucessor = null;
            foreach (int _sucessor in sucessores)
            {
                try
                {
                    Noh to = CalculaCaminho(_sucessor, dest);
                    int DistanciaDoSucessor = _distancias[src, _sucessor];
                    if ((NohDoSucessor == null) || (NohDoSucessor.distancia == INF) || (DistanciaDoSucessor < NohDoSucessor.distancia))
                    {
                        NohDoSucessor = new Noh(_sucessor, DistanciaDoSucessor, to);
                    }
                    comparacoes++;
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            stack.Pop();
            if (NohDoSucessor == null)
            {
                return null;
                // throw new Exception();
            }
            return NohDoSucessor;
        }




        private bool sucessor(int u, int z)
        {
            return ((_distancias[u, z] != INF) && u != z && (_distancias[u , z] > 0));
        }

    }
}
