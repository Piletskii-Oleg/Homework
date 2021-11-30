int** create(int n)
{
    int** p = (int**)malloc(n * sizeof(int*));
    for (int k = 0; k < n; k++)
    {
        p[k] = (int*)malloc(10 * sizeof(int));
    }
    return p;
}

int* access(int** M, int i, int j, int n)
{
    static int dummy;
    dummy = 0;

    if (i < 0 || i >= n || j < 0 || j >= n)
        exit(1);
    if ((i / 10) != (j / 10)) return &dummy;

    return &M[i][j % 10];
}

void destroy(int** M, int m)
{
    for (int i = 0; i < m; i++)
    {
        free(M[i]);
    }
    free(M);
}