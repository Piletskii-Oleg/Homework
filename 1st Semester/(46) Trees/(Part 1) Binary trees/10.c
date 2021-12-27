UNFINISHED
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

binNode* leftmostLeaf(binNode* root)
{
	if (root == NULL)
		return NULL;

	while (root->left != NULL)
		root = root->left;
	while (root->right != NULL)
	{
		root = root->right;

		while (root->left != NULL)
			root = root->left;
	}

	return root;
}
UNFINISHED
UNFINISHED
UNFINISHED
void deleteLeftmostLeaf(binNode* root)
{
	if (root == NULL)
		return;

	binNode* leaf = leftmostLeaf(root);
	free(leaf);
	leaf = NULL;
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
	deleteLeftmostLeaf(tree);
	printTree(tree, 3);
	return 0;
}
