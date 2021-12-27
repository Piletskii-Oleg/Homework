#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

int digit(int number, int key)
{
	key = key >> number;
	return key % 2;
}

int main()
{
	printf("%d", digit(0, 25));
}
