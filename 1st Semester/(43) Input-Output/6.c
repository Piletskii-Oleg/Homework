int sum(char path[])
{
    FILE* fptr;
    fptr = fopen(path, "rb");
    int sum = 0;
    char str[100];

    while (fscanf(fptr, "%s", str) > 0)
    {
        sum += atoi(str);
    }

    return sum;
}