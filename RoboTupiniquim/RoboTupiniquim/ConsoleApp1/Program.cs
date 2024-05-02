namespace RoboTupiniquim //fiz com ajuda
{
    public class Robo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direcao { get; set; }

        public Robo(int x, int y, char direcao)
        {
            X = x;
            Y = y;
            Direcao = direcao;
        }

        public void Mover(string comandos)
        {
            foreach (char comando in comandos)
            {
                if (comando == 'E')
                {
                    GirarEsquerda();
                }
                else if (comando == 'D')
                {
                    GirarDireita();
                }
                else if (comando == 'M')
                {
                    MoverFrente();
                }
            }
        }

        private void GirarEsquerda()
        {
            switch (Direcao)
            {
                case 'N':
                    Direcao = 'O';
                    break;
                case 'S':
                    Direcao = 'L';
                    break;
                case 'L':
                    Direcao = 'N';
                    break;
                case 'O':
                    Direcao = 'S';
                    break;
            }
        }

        private void GirarDireita()
        {
            switch (Direcao)
            {
                case 'N':
                    Direcao = 'L';
                    break;
                case 'S':
                    Direcao = 'O';
                    break;
                case 'L':
                    Direcao = 'S';
                    break;
                case 'O':
                    Direcao = 'N';
                    break;
            }
        }

        private void MoverFrente()
        {
            switch (Direcao)
            {
                case 'N':
                    Y++;
                    break;
                case 'S':
                    Y--;
                    break;
                case 'L':
                    X++;
                    break;
                case 'O':
                    X--;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{X},{Y},{Direcao}";
        }
    }

    public class PlanoCoordenadas
    {
        public int Altura { get; set; }
        public int Largura { get; set; }

        public PlanoCoordenadas(int altura, int largura)
        {
            Altura = altura;
            Largura = largura;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o tamanho do plano de coordenadas (formato: X Y):");
            string[] dimensoes = Console.ReadLine().Split(' ');
            int largura = int.Parse(dimensoes[0]);
            int altura = int.Parse(dimensoes[1]);

            PlanoCoordenadas plano = new PlanoCoordenadas(altura, largura);

            Console.WriteLine("Informe o número de robôs:");
            int numeroRobos = int.Parse(Console.ReadLine());

            List<Robo> robos = new List<Robo>();

            for (int i = 0; i < numeroRobos; i++)
            {
                Console.WriteLine($"Robô {i + 1}:");
                Console.WriteLine("Informe a posição inicial e a direção (formato: X Y D):");
                string[] posicaoInicial = Console.ReadLine().Split(' ');
                int x = int.Parse(posicaoInicial[0]);
                int y = int.Parse(posicaoInicial[1]);
                char direcao = char.Parse(posicaoInicial[2]);

                Console.WriteLine("Informe as ordens de movimento (formato: E, D ou M):");
                string comandos = Console.ReadLine();

                Robo robo = new Robo(x, y, direcao);
                robo.Mover(comandos);

                Console.WriteLine($"Posição final do robô {i + 1}: {robo}");
            }
        }
    }
}