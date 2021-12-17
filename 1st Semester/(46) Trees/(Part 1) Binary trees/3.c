#include <stdio.h>
#include <math.h>
#include <stdlib.h> //accep
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

typedef struct BNode
{
	int data;
	struct BNode* left, * right;
} binNode;

struct BNode* replace(struct BNode* root)
{
	binNode* newRoot = root->left;
	binNode* rightSon = root->right;

	root->right = newRoot->right;
	root->left = newRoot->left;

	newRoot->left = root;
	newRoot->right = rightSon;

	return newRoot;
}

struct BNode* newTree(int data, struct BNode* left, struct BNode* right)
{
	struct BNode* root = (struct BNode*)malloc(sizeof(struct BNode));
	root->data = data;
	root->left = left;
	root->right = right;
	return root;
}

void printTree(struct BNode* root, int offset)
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
	struct BNode* tree = newTree(1, newTree(2, newTree(4, 0, 0), newTree(5, 0, 0)), newTree(3, newTree(6, 0, 0), 0));
	printTree(tree, 2);

	printf("\n");
	tree = replace(tree);
	printTree(tree, 2);
	return 0;
}
