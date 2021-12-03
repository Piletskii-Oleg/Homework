void count_symbols(char path[]) //a)
{
    FILE* fptr;
    fptr = fopen(path, "rb");

    char str[3];
    int count[256];
    for (int i = 0; i < 256; i++)
        count[i] = 0;

    while (fgets(str, 2, fptr) > 0)
    {
        count[str[0]]++;
    }

    for (int i = 0; i < 256; i++)
    {
        if (count[i] != 0)
            printf("%c - %d\n", (char)i, count[i]);
    }
    fclose(fptr);
}