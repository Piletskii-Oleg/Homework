#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

typedef struct BNode
{
	int data;
	struct BNode* left, * right;
} binNode;

binNode* leftTurn(binNode* root)
{
	binNode* newRoot = root->right;
	binNode* toMove = root->right->left;

	newRoot->left = root;
	root->right = toMove;

	return newRoot;
}

binNode* newTree(int data, binNode* left, binNode* right)
{
	binNode* root = (binNode*)malloc(sizeof(binNode));
	root->data = data;
	root->left = left;
	root->right = right;
	return root;
}

void printTree(binNode* root, int offset)
{
	if (root == NULL)
		return;

	printTree(root->right, offset + 3);
	for (int i = 0; i < offset; i++)
	{
		printf(" ");
	}
	printf("%d\n", root->data);
	printTree(root->left, offset + 3);
}

int main()
{
	binNode* tree = newTree(1, newTree(2, newTree(4, 0, 0), newTree(5, 0, 0)), newTree(3, newTree(6, 0, 0), newTree(2, 0, 0)));
	printTree(tree, 3);

	printf("\n\n\n");
	tree = leftTurn(tree);
	printTree(tree, 3);
	return 0;
}
