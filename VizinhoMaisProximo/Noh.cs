using System;
using System.Collections.Generic;
using System.Text;

namespace VizinhoMaisProximo
{
    class Noh
    {

        public int nohAtual;
        public int distancia;
        public Noh proximo;

        public Noh(int currentNoh, int dist, Noh next)
        {
            this.nohAtual = currentNoh;
            this.distancia = dist;
            this.proximo = next;
        }
    }
}
