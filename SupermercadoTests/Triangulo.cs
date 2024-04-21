namespace SupermercadoTests
{
    public class Triangulo
    {
        private double LadoA;
        private double LadoB;
        private double LadoC;

        // Construtor
        public Triangulo(double ladoA, double ladoB, double ladoC)
        {
            LadoA = ladoA;
            LadoB = ladoB;
            LadoC = ladoC;
        }

        public bool EhEquilatero()
        {
            return LadoA == LadoB && LadoA == LadoB;
        }

        public bool EhIsosceles()
        {
            return LadoA == LadoB || LadoA == LadoC || LadoB == LadoC;
        }

        public bool EhEscaleno()
        {
            return LadoA != LadoB && LadoA != LadoC && LadoB != LadoC;
        }
    }
}
