#include <stdio.h>

int main()
{
    double d; int i; int ii;
    int* pi = &i;
    int* pii = &ii;
    double* pd = &d;
    ((int*)pd)[0] = &i;
    ((int*)pd)[1] = &ii;
    return EXIT_SUCCESS;
}
