#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct DSNode
{
	int key;
	int data;
	struct DSNode* left, * right;
};

int main()
{
	printf("%d", digit(4, 25));
}
