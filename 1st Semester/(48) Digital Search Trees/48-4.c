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

void insert(struct DSNode* root, int key, int data, int currentDigit)
{
	if (!root)
		return;

	struct DSNode* newNode = (struct DSNode*)malloc(sizeof(struct DSNode));
	if (digit(currentDigit, key) == 0)
	{
		if (root->left == 0)
		{
			root->left = newNode;
		}
		else
		{
			insert(root->left, key, data, currentDigit + 1);
		}
	}
	else
	{
		if (root->right == 0)
		{
			root->right = newNode;
		}
		else
		{
			insert(root->right, key, data, currentDigit + 1);
		}
	}

	newNode->left = NULL;
	newNode->right = NULL;
	newNode->data = data;
	newNode->key = key;
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

int main()
{
	struct DSNode* tree = newTree(5, 3, newTree(4, 10, 0, 0), newTree(9, 1, 0, newTree(87, 32, 0, 0)));
	printTree(tree, 3);
	printf("%d", search(tree, 87)->data);
	insert(tree, 29, 2, 0);
	insert(tree, 31, 2, 0);
	insert(tree, 1, 2, 0);
	printf("\n\n");
	printTree(tree, 7);
}
