void copy(char path1[], char path2[])
{
    FILE* fptr, *gptr;
    fptr = fopen(path1, "rb");
    gptr = fopen(path2, "wb");

    char str[129];
    while (fgets(str, 128, fgets) > 0)
    {
        fprintf(gptr, "%s", str);
    }

    fclose(fptr);
    fclose(gptr);
}

void copy_append(char path1[], char path2[])
{
    FILE* fptr, *gptr;
    fptr = fopen(path1, "rb");
    gptr = fopen(path2, "ab");

    char str[129];
    while (fgets(str, 128, fptr) > 0)
    {
        fprintf(gptr, "%s", str);
    }

    fclose(fptr);
    fclose(gptr);
}

int main()
{
    FILE* fptr, * gptr;
    char str1[100] = "C:\\Users\\Oleg\\source\\repos\\C Tests\\C Tests\\f.txt";
    char str2[100] = "C:\\Users\\Oleg\\source\\repos\\C Tests\\C Tests\\g.txt";
    copy(str1, str2);
}