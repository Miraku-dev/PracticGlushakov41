double start = Math.PI / 4;
double end = Math.PI / 2;
int M = 15;
double step = (end - start) / M;

for (int i = 0; i <= M; i++)
{
    double x = start + i * step;
    double result = 1 / Math.Tan(x);
    Console.WriteLine($"x = {x}, Ctg(x) = {result}");
}