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

int digit(int number, int key)
{
	key = key >> number;
	return key % 2;
}

struct DSNode* newTree(int key, int data, struct DSNode* left, struct DSNode* right)
{
	struct DSNode* root = (struct DSNode*)malloc(sizeof(struct DSNode));
	root->key = key;
	root->data = data;
	root->left = left;
	root->right = right;
	return root;
}

void printTree(struct DSNode* root, int offset)
{
	if (!root)
		return;

	printTree(root->right, offset + 7);
	for (int i = 0; i < offset; i++)
		printf(" ");
	printf("%d->%d\n", root->key, root->data);
	printTree(root->left, offset + 7);
}

struct DSNode* search(struct DSNode* root, int key)
{
	if (!root)
		return NULL;
	if (root->key == key)
		return root;

	int keyCopy = key;
	while (!root || root->key != key)
	{
		if (keyCopy % 2 == 0)
		{
			if (root->left)
				root = root->left;
			else
				break;
		}
		else
		{
			if (root->right)
				root = root->right;
			else
				break;
		}

		keyCopy >> 1;
	}

	if (root->key == key)
		return root;
	else
		return NULL;
}

void delete(struct DSNode* root, int key)
{
	if (!root)
		return;
	int currentDigit = 0;

	struct DSNode* copy = root;
	while (root->key != key)
	{
		copy = root;
		if (digit(currentDigit, key))
			root = root->right;
		else
			root = root->left;
		currentDigit++;
	}

	if (digit(currentDigit, key))
		copy->right = NULL;
	else
		copy->left = NULL;
	free(root);
}

int main()
{
	struct DSNode* tree = newTree(5, 3, newTree(4, 10, 0, 0), newTree(9, 1, 0, newTree(87, 32, 0, 0)));
	printTree(tree, 3);
	printf("\n\n");
	delete(tree, 87);
	printTree(tree, 3);
}
