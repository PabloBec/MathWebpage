namespace HerramientasMates
{
    public class Maths
    {
        // Funcion Mcd:
        public static int Mcd(int aI, int bI)
        {
            int entero1, entero2;

            // Ajuste para asegurarse de que entero1 es mayor.
            if (aI < bI)
            {
                entero1 = bI;
                entero2 = aI;
            }
            else
            {
                entero1 = aI;
                entero2 = bI;
            }

            // Bucle de iteraciones (Algoritmo de Euclides)
            int resto = entero1 % entero2;
            while (resto != 0)
            {
                entero1 = entero2;
                entero2 = resto;

                resto = entero1 % entero2;
            }

            return entero2;
        }

        // Funcion Mcm:
        public static int Mcm(int aI, int bI)
        {
            int entero1 = aI, entero2 = bI;

            // Obtenemos el mcd(a,b):
            int d = Mcd(entero1, entero2);

            // mcm(a,b) = a*b/d;
            int c = entero1 * entero2 / d;

            return c;
        }

        // Funcion Bezout:
        public static int[] Bezout(int aI, int bI)
        {
            // Asegurarse de que entero1 es mayor:
            int entero1, entero2;
            if (aI < bI)
            {
                entero1 = bI;
                entero2 = aI;
            }
            else
            {
                entero1 = aI;
                entero2 = bI;
            }

            // Setup de a,b,q,r:
            List<int> a = new List<int>(), b = new List<int>(), q = new List<int>(), r = new List<int>();
            a.Add(entero1);
            b.Add(entero2);
            double qCociente = a[0] / b[0];
            q.Add((int)Math.Floor(qCociente));
            r.Add(entero1 % entero2);

            // Console.WriteLine($"a = [{a[0]}], b = [{b[0]}], q = [{q[0]}], r = [{r[0]}].");  // Para debug

            // BUCLE: 
            int i = 0;
            while (r[i] != 0)
            {
                a.Add(b[i]);
                b.Add(r[i]);
                i++;
                qCociente = a[i] / b[i];
                q.Add((int)Math.Floor(qCociente));
                r.Add(a[i] % b[i]);
            }

            // Output:
            int iter = i + 1;
            int[] lambda = new int[iter], mu = new int[iter];
            i--;
            lambda[i] = 1;
            mu[i] = -q[i];
            i--;

            while (i >= 0)
            {
                lambda[i] = mu[i + 1];
                mu[i] = lambda[i + 1] - q[i] * mu[i + 1];
                i--;
            }

            //Console.WriteLine($"La identidad de Bezout de {entero1} y {entero2} es:\n{b.Last()} = ({lambda[0]})*({entero1}) + ({mu[0]})*({entero2})\n");
            return new int[5] { b.Last(), lambda[0], entero1, mu[0], entero2 };
        }

        // Bezout Display y mcm Display: Devuelven un string para dar salida con @Model.BezoutString (declarado en Bezout.cshtml.cs)
        public static string BezoutDisplay(int aI, int bI)
        {
            int[] idBezout = Bezout(aI, bI);
            return $"{idBezout[0]} = ({idBezout[1]})({idBezout[2]}) + ({idBezout[3]})({idBezout[4]})";
        }

        public static string[] mcmDisplay(int aI, int bI)
        {
            int mcdAB = Mcd(aI, bI);
            int mcmAB = Mcm(aI, bI);
            return new string[] { $"{mcdAB}" , $"{mcmAB}" };
        }

        // Funcion Bezout4:

    }
}
