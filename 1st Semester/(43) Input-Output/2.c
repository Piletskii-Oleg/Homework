int main() //a)
{
    FILE* fptr;
    fptr = fopen("C:\\Users\\Oleg\\source\\repos\\C Tests\\C Tests\\g.txt", "r");

    char name[15];
    int math, phys;

    while (fscanf(fptr, "%s %d %d", name, &math, &phys) > 0)
    {
        printf("%s\t%d %d\n", name, math, phys);
    }
    fclose(fptr);
}

int main() //b)
{
    FILE* fptr;
    fptr = fopen("C:\\Users\\Oleg\\source\\repos\\C Tests\\C Tests\\g.txt", "r");

    char title[30];
    fscanf(fptr, "%[^\n]", title);
    printf("%s\n", title);

    while (fscanf(fptr, "%s %d %d", name, &math, &phys) > 0)
    {
        printf("%s\t%d %d\n", name, math, phys);
    }
    fclose(fptr);
}