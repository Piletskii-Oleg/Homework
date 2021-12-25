#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct ANode
{
	int data;
	struct ANode* son, * brother;
};

struct ANode* findPointer(struct ANode* root, int steps[], int stepsLength)
{
	int currentStep;
	for (int i = 0; i < stepsLength; i++)
	{
		root = root->son;
		for (int j = 0; j < steps[i]; j++)
		{
			root = root->brother;
		}
	}
	return root;
}

struct ANode* g(int data, struct ANode* son, struct ANode* brother)
{
	struct ANode* newNode = (struct ANode*)malloc(sizeof(struct ANode));
	newNode->data = data;
	newNode->son = son;
	newNode->brother = brother;
	return newNode;
}

void printTree(struct ANode* root, int offset)
{
	if (!root)
		return;

	for (int i = 0; i < offset; i++)
		printf(" ");

	printf("%d\n", root->data);
	printTree(root->son, offset + 3);
	printTree(root->brother, offset);
}

int main()
{
	struct ANode* tree = g(1, g(2, g(5, 0, g(6, 0, g(7, 0, 0))), g(3, g(8, 0, 0), g(4, g(9, 0, g(10, 0, 0)), 0))), 0);

	printTree(tree, 3);
}
