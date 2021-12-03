int main()
{
    FILE* fptr;
    fptr = fopen("C:\\Users\\Oleg\\source\\repos\\C Tests\\C Tests\\f.txt", "w");

    fprintf(fptr, "%s", "x\t\tsin(x)\n");
    for (double i = 0.0; i < 1.0; i += 0.1)
    {
        fprintf(fptr, "%lf\t%lf\n", i, sin(i));
    }
    fclose(fptr);
}