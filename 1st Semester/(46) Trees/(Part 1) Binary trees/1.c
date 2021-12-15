#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#define _CRT_SECURE_NO_WARNINGS

struct BNode
{
	int data;
	struct BNode* left, * right;
};

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

struct BNode* rightmostGrandson(struct BNode* root, int kin)
{
	if (root == NULL)
		return NULL;

	if (kin == 2)
		return root;

	if (root->right != NULL)
		rightmostGrandson(root->right, kin + 1);
	else if (root->left != NULL)
		rightmostGrandson(root->left, kin + 1);
	else
		return NULL;
}

struct BNode* rightmostSon(struct BNode* side)
{
	if (side->right == NULL)
	{
		if (side->left == NULL)
		{
			return NULL;
		}
		else
		{
			return side->left;
		}
	}
	else
	{
		return side->right;
	}
}

struct BNode* rightmostGrandsonB(struct BNode* root)
{
	if (root->right == NULL || (root->right->left == NULL && root->right->right == NULL))
	{
		if (root->left == NULL)
		{
			return NULL;
		}
		else
		{
			rightmostSon(root->left);
		}
	}
	else
	{
		if (root->right->right == NULL)
		{
			return root->right->left;
		}
		else
		{
			return root->right->right;
		}
	}
}

int main()
{
	struct BNode* tree = newTree(1, newTree(2, newTree(4, 0, 0), newTree(5, 0, 0)), newTree(3, newTree(6, 0, 0), 0));
	printf("%d", rightmostGrandsonB(tree)->data);
}
