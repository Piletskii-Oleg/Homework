void printWithoutName(char path[], int size)
{
    int lastPoint = -1;
    for (int i = 0; i < size; i++)
    {
        if (path[i] == '\\')
            lastPoint = i;
    }

    if (lastPoint == -1)
    {
        printf("Error.");
    }
    else
    {
        for (int i = 0; i < lastPoint; i++)
            printf("%c", path[i]);
    }
    printf("\n");
}

void printNameWithExtension(char path[], int size)
{
    int lastPoint = -1;
    for (int i = 0; i < size; i++)
    {
        if (path[i] == '\\')
            lastPoint = i;
    }

    if (lastPoint == -1)
    {
        printf("Error.");
    }
    else
    {
        for (int i = lastPoint + 1; path[i] != '\0'; i++)
        {
            printf("%c", path[i]);
        }
    }
    printf("\n");
}

void printExtension(char path[], int size)
{
    int lastPoint = -1;
    for (int i = 0; i < size; i++)
    {
        if (path[i] == '.')
            lastPoint = i;
    }

    if (lastPoint == -1)
    {
        printf("Error.");
    }
    else
    {
        for (int i = lastPoint + 1; path[i] != '\0'; i++)
        {
            printf("%c", path[i]);
        }
    }
    printf("\n");
}

void printOnlyName(char path[], int size)
{
    int lastSlash = -1;
    int lastPoint = -1;
    for (int i = 0; i < size; i++)
    {
        if (path[i] == '\\')
            lastSlash = i;
        if (path[i] == '.')
            lastPoint = i;
    }

    if (lastSlash == -1)
    {
        printf("Error.");
    }

    else
    {
        for (int i = lastSlash + 1; i < lastPoint; i++)
        {
            printf("%c", path[i]);
        }
    }
    printf("\n");
}

void printLastFolder(char path[], int size)
{
    int lastPoint = -1;
    int preLastPoint = -1;
    for (int i = 0; i < size; i++)
    {
        if (path[i] == '\\')
        {
            preLastPoint = lastPoint;
            lastPoint = i;
        }
    }

    if (lastPoint == -1)
    {
        printf("Error.");
    }
    else
    {
        for (int i = preLastPoint + 1; i < lastPoint; i++)
        {
            printf("%c", path[i]);
        }
    }
    printf("\n");
}

void printHTML(char path[], int size)
{
    int lastPoint = -1;
    for (int i = 0; i < size; i++)
    {
        if (path[i] == '.')
            lastPoint = i;
    }

    if (lastPoint == -1)
    {
        printf("Error.");
    }
    else
    {
        for (int i = 0; i <= lastPoint; i++)
        {
            printf("%c", path[i]);
        }
        printf("html");
    }
    printf("\n");
}

int main()
{
    char path[100] = "C:\\Users\\Oleg\\source\\repos\\uue.rweu.txt";

    printWithoutName(path, 100);
    printNameWithExtension(path, 100);
    printExtension(path, 100);
    printOnlyName(path, 100);
    printLastFolder(path, 100);
    printHTML(path, 100);
}
