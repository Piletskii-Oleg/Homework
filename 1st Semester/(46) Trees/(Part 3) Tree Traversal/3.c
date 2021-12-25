#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS
struct BNode
{
	int data;
	struct BNode* left, *right;
};

int minElement(struct BNode* root)
{
	if (!root)
		return 0;
	else if (!root->left && !root->right)
		return root->data;
	else if (!root->left && root->right)
	{
		int right = minElement(root->right);
		return min(right, root->data);
	}
	else if (root->left && !root->right)
	{
		int left = minElement(root->left);
		return min(left, root->data);
	}
	else
	{
		int right = minElement(root->right);
		int left = minElement(root->left);
		return min(root->data, min(right, left));
	}
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
	struct BNode* tree = newTree(9, newTree(2, newTree(4, 0, 0), newTree(5, 0, 0)), newTree(3, newTree(6, 0, 0), 0));

	printTree(tree, 3);
	printf("%d", minElement(tree));
}
