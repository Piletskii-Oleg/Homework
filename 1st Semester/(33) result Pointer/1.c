int* pointerMinimum(int *a, int *b)
{
    if (*a < *b)
        return a;
    else
        return b;
}

int* minimum()
{
    static int a = 4;
    static int b = 10;
    static int c = 8;

    return pointerMinimum(pointerMinimum(&a, &b), &c);
}